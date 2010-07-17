using System;
using System.Text;
using System.Diagnostics;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {

    #region IHpricotDataContainer

    public interface IHpricotDataContainer {
        T GetData<T>() where T : BasicData;
    }

    #endregion

    [RubyModule("Hpricot")]
    public static class Hpricot {
        #region Hpricot

        // TODO: ProcInsParse seems to be actually unused in ruby code. I'll leave it here for now, 
        //       but I think it is safe to remove it.
        [RubyConstant("ProcInsParse")]
        public static readonly RubyRegex ProcInsParse = HpricotScanner.ProcInsParse;

        [RubyMethod("scan", RubyMethodAttributes.PublicSingleton)]
        public static Object Scan(ConversionStorage<MutableString>/*!*/ toMutableStringStorage, RespondToStorage/*!*/ respondsTo, 
            BinaryOpStorage/*!*/ readIOStorage, BlockParam block, RubyModule/*!*/ self, Object/*!*/ source, Hash/*!*/ options) {

            // TODO: improve me please!
            Object elementContent;
            if (!self.TryGetConstant(null, "ElementContent", out elementContent) && !(elementContent is Hash)) {
                throw new Exception("Hpricot::ElementContent is missing or it is not an Hash");
            }

            //NOTE: block can be null as of Hpricot 0.7, see HpricotScanner.ELE
            HpricotScanner scanner = new HpricotScanner(respondsTo, toMutableStringStorage, readIOStorage, block);
            return scanner.Scan(source, options, elementContent as Hash);
        }

        [RubyMethod("css", RubyMethodAttributes.PublicSingleton)]
        public static Object Css(RubyContext/*!*/ context, BlockParam/*!*/ block, RubyModule/*!*/ self) {
            return null;
        }

        [RubyMethod("buffer_size", RubyMethodAttributes.PublicSingleton)]
        public static Int32? GetBufferSize(RubyModule/*!*/ self) {
            return HpricotScanner.BufferSize;
        }

        [RubyMethod("buffer_size=", RubyMethodAttributes.PublicSingleton)]
        public static void SetBufferSize(RubyModule/*!*/ self, Int32 bufferSize) {
            // TODO: thread safety
            HpricotScanner.BufferSize = bufferSize;
        }

        #endregion


        #region Hpricot::Doc

        [RubyClass("Doc")]
        public class Document : IHpricotDataContainer {
            private RubyContext _context;
            private ElementData _data;

            public Document(ScannerState state) 
                : this(state.Context) { 
            }

            public Document(RubyContext context) 
                : this(context, new ElementData()) { 
            }

            public Document(RubyContext context, ElementData data) {
                _context = context;
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static Document Allocator(RubyClass/*!*/ self) {
                return new Document(self.Context);
            }

            [RubyMethod("children")]
            public static Object GetChildren(Document/*!*/ self) {
                return self._data.Children;
            }

            [RubyMethod("children=")]
            public static void SetChildren(Document/*!*/ self, Object/*!*/ children) {
                self._data.Children = children;
            }
        }

        #endregion

        #region Hpricot::BaseEle

        [RubyClass("BaseEle")]
        public abstract class BaseElement : IHpricotDataContainer {
            protected RubyContext _context;
            protected BasicData _data;

            public BaseElement(ScannerState state) 
                : this(state.Context, new BasicData()) { 
            }

            public BaseElement(ScannerState state, BasicData data)
                : this(state.Context, data) {
            }

            public BaseElement(RubyContext context) 
                : this(context, new BasicData()) {
            }

            public BaseElement(RubyContext context, BasicData data) {
                _context = context;
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            protected virtual MutableString RawString {
                get {
                    return _data.Tag != null ? _data.Tag as MutableString : MutableString.CreateEmpty();
                }
            }

            [RubyMethod("raw_string")]
            public static MutableString GetRawString(BaseElement/*!*/ self) {
                return self.RawString;
            }

            [RubyMethod("parent")]
            public static Object GetParent(BaseElement/*!*/ self) {
                return self._data.Parent;
            }

            [RubyMethod("parent=")]
            public static void SetParent(BaseElement/*!*/ self, Object/*!*/ parent) {
                self._data.Parent = parent;
            }
        }

        #endregion

        #region Hpricot::CData 

        [RubyClass("CData", Inherits = typeof(BaseElement))]
        public class CData : BaseElement {
            public CData(ScannerState state) 
                : this(state.Context) { 
            }

            public CData(RubyContext context)
                : base(context) {
            }

            [RubyConstructor]
            public static CData Allocator(RubyClass/*!*/ self) {
                return new CData(self.Context);
            }

            protected override MutableString RawString {
                get {
                    return MutableString.CreateAscii(String.Format("<![CDATA[{0}]]>", GetContent(this)));
                }
            }

            [RubyMethod("content")]
            public static MutableString GetContent(CData/*!*/ self) {
                return self._data.Tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(CData/*!*/ self, Object/*!*/ content) {
                self._data.Tag = content;
            }
        }

        #endregion

        #region Hpricot::Comment

        [RubyClass("Comment", Inherits = typeof(BaseElement))]
        public class Comment : BaseElement {
            public Comment(ScannerState state) 
                : this(state.Context) { 
            }

            public Comment(RubyContext context)
                : base(context) {
            }

            [RubyConstructor]
            public static Comment Allocator(RubyClass/*!*/ self) {
                return new Comment(self.Context);
            }

            protected override MutableString RawString {
                get {
                    return MutableString.CreateAscii(String.Format("<!--{0}-->", GetContent(this)));
                }
            }

            [RubyMethod("content")]
            public static MutableString GetContent(Comment/*!*/ self) {
                return self._data.Tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(Comment/*!*/ self, Object/*!*/ content) {
                self._data.Tag = content;
            }
        }

        #endregion

        #region Hpricot::DocType

        [RubyClass("DocType", Inherits = typeof(BaseElement))]
        public class DocumentType : BaseElement {
            private static readonly SymbolId _systemId = SymbolTable.StringToId("system_id");
            private static readonly SymbolId _publicId = SymbolTable.StringToId("public_id");

            public DocumentType(ScannerState state) 
                : this(state.Context) { 
            }

            public DocumentType(RubyContext context)
                : base(context, new AttributeData()) {
            }

            [RubyConstructor]
            public static DocumentType Allocator(RubyClass/*!*/ self) {
                return new DocumentType(self.Context);
            }

            protected override MutableString RawString {
                get {
                    MutableString doctype = MutableString.CreateAscii("");
                    doctype.AppendFormat("<!DOCTYPE {0} ", GetTarget(this));

                    AttributeData data = _data as AttributeData;
                    if (!data.AttrIsNull) {
                        object publicId = GetPublicId(this);
                        doctype.Append(publicId != null ? String.Format("PUBLIC \"{0}\"", publicId) : "SYSTEM");

                        object systemId = GetSystemId(this);
                        if (systemId != null) {
                            doctype.AppendFormat(" \"{0}\"", systemId.ToString().Replace("\"", "\\\""));
                        }
                    }

                    doctype.Append(">");
                    return doctype;
                }
            }

            [RubyMethod("target")]
            public static Object GetTarget(DocumentType/*!*/ self) {
                return self._data.Tag;
            }

            [RubyMethod("target=")]
            public static void SetTarget(DocumentType/*!*/ self, Object/*!*/ target) {
                self._data.Tag = target;
            }

            [RubyMethod("public_id")]
            public static Object GetPublicId(DocumentType/*!*/ self) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    return null;
                }

                Object value;
                (data.Attr as Hash).TryGetValue(_publicId, out value);
                return value;
            }

            [RubyMethod("public_id=")]
            public static void SetPublicId(RubyContext context/*!*/, DocumentType/*!*/ self, Object/*!*/ publicId) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    data.Attr = new Hash(context);
                }
                (data.Attr as Hash)[_publicId] = publicId;
            }

            [RubyMethod("system_id")]
            public static Object GetSystemId(DocumentType/*!*/ self) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    return null;
                }

                Object value;
                (data.Attr as Hash).TryGetValue(_systemId, out value);
                return value;
            }

            [RubyMethod("system_id=")]
            public static void SetSystemId(RubyContext context/*!*/, DocumentType/*!*/ self, Object/*!*/ systemId) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    data.Attr = new Hash(context);
                }
                (data.Attr as Hash)[_systemId] = systemId;
            }
        }

        #endregion

        #region Hpricot::Elem

        [RubyClass("Elem", Inherits = typeof(BaseElement))]
        public class Element : BaseElement {
            public Element(ScannerState state) 
                : this(state.Context) { 
            }

            public Element(RubyContext context)
                : base(context, new ElementData()) {
            }

            [RubyConstructor]
            public static Element Allocator(RubyClass/*!*/ self) {
                return new Element(self.Context);
            }

            [RubyMethod("raw_string")]
            public static Object GetRawString(Element/*!*/ self) {
                return (self._data as ElementData).Raw;
            }

            [RubyMethod("clear_raw")]
            public static bool ClearRaw(Element/*!*/ self) {
                (self._data as ElementData).Raw = null;
                return true;
            }

            [RubyMethod("raw_attributes")]
            public static Object GetRawAttributes(Element/*!*/ self) {
                return (self._data as ElementData).Attr;
            }

            [RubyMethod("raw_attributes=")]
            public static void SetRawAttributes(Element/*!*/ self, Object/*!*/ rawAttributes) {
                (self._data as ElementData).Attr = rawAttributes;
            }

            [RubyMethod("children")]
            public static Object GetChildren(Element/*!*/ self) {
                return (self._data as ElementData).Children;
            }

            [RubyMethod("children=")]
            public static void SetChildren(Element/*!*/ self, Object/*!*/ children) {
                (self._data as ElementData).Children = children;
            }

            [RubyMethod("etag")]
            public static Object GetEtag(Element/*!*/ self) {
                return (self._data as ElementData).ETag;
            }

            [RubyMethod("etag=")]
            public static void SetEtag(Element/*!*/ self, Object/*!*/ etag) {
                (self._data as ElementData).ETag = etag;
            }

            [RubyMethod("name")]
            public static Object GetName(Element/*!*/ self) {
                return self._data.Tag;
            }

            [RubyMethod("name=")]
            public static void SetName(Element/*!*/ self, Object/*!*/ name) {
                self._data.Tag = name;
            }
        }

        #endregion
        
        #region Hpricot::ETag

        [RubyClass("ETag", Inherits = typeof(BaseElement))]
        public class ETag : BaseElement {
            public ETag(ScannerState state) 
                : this(state.Context) { 
            }

            public ETag(RubyContext context)
                : base(context, new AttributeData()) {
            }

            [RubyConstructor]
            public static ETag Allocator(RubyClass/*!*/ self) {
                return new ETag(self.Context);
            }

            [RubyMethod("raw_string")]
            public static MutableString GetRawString(ETag/*!*/ self) {
                Debug.Assert(self._data is AttributeData, "self._data is not an instance of AttributeData");
                return (self._data as AttributeData).Attr as MutableString;
            }

            [RubyMethod("clear_raw")]
            public static bool ClearRaw(ETag/*!*/ self) {
                Debug.Assert(self._data is AttributeData, "self._data is not an instance of AttributeData");
                (self._data as AttributeData).Attr = null;
                return true;
            }

            [RubyMethod("name")]
            public static Object GetName(ETag/*!*/ self) {
                return self._data.Tag;
            }

            [RubyMethod("name=")]
            public static void SetName(ETag/*!*/ self, Object/*!*/ name) {
                self._data.Tag = name;
            }
        }

        #endregion

        #region Hpricot::BogusETag

        [RubyClass("BogusETag", Inherits = typeof(ETag))]
        public class BogusETag : ETag {
            public BogusETag(ScannerState state) 
                : this(state.Context) { 
            }

            public BogusETag(RubyContext context)
                : base(context) {
            }

            [RubyConstructor]
            public static new BogusETag Allocator(RubyClass/*!*/ self) {
                return new BogusETag(self.Context);
            }
        }

        #endregion
        
        #region Hpricot::Text

        [RubyClass("Text", Inherits = typeof(BaseElement))]
        public class Text : BaseElement {
            public Text(ScannerState state) 
                : this(state.Context) { 
            }

            public Text(RubyContext context)
                : base(context) {
            }

            [RubyConstructor]
            public static Text Allocator(RubyClass/*!*/ self) {
                return new Text(self.Context);
            }

            [RubyMethod("content")]
            public static MutableString GetContent(Text/*!*/ self) {
                return self._data.Tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(Text/*!*/ self, Object/*!*/ content) {
                self._data.Tag = content;
            }
        }

        #endregion

        #region Hpricot::XMLDecl

        [RubyClass("XMLDecl", Inherits = typeof(BaseElement))]
        public class XmlDeclaration : BaseElement {
            private static readonly SymbolId _encoding = SymbolTable.StringToId("encoding");
            private static readonly SymbolId _standalone = SymbolTable.StringToId("standalone");
            private static readonly SymbolId _version = SymbolTable.StringToId("version");

            public XmlDeclaration(ScannerState state) 
                : this(state.Context) { 
            }

            public XmlDeclaration(RubyContext context)
                : base(context, new AttributeData()) {
            }

            [RubyConstructor]
            public static XmlDeclaration Allocator(RubyClass/*!*/ self) {
                return new XmlDeclaration(self.Context);
            }

            protected override MutableString RawString {
                get {
                    MutableString xmldecl = MutableString.CreateAscii("");
                    xmldecl.AppendFormat("<?xml version=\"{0}\"", GetVersion(this));

                    AttributeData data = _data as AttributeData;
                    if (!data.AttrIsNull) {
                        object encoding = GetEncoding(this);
                        if (encoding != null) {
                            xmldecl.AppendFormat(" encoding=\"{0}\"", encoding);
                        }

                        object standalone = GetStandalone(this);
                        if (standalone != null) {
                            xmldecl.AppendFormat(" standalone=\"{0}\"", standalone);
                        }
                    }

                    xmldecl.Append("?>");
                    return xmldecl;
                }
            }

            [RubyMethod("encoding")]
            public static Object GetEncoding(XmlDeclaration/*!*/ self) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    return null;
                }

                Object value;
                (data.Attr as Hash).TryGetValue(_encoding, out value);
                return value;
            }

            [RubyMethod("encoding=")]
            public static void SetEncoding(RubyContext/*!*/ context, XmlDeclaration/*!*/ self, Object/*!*/ encoding) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    data.Attr = new Hash(context);
                }
                (data.Attr as Hash)[_encoding] = encoding;
            }

            [RubyMethod("standalone")]
            public static Object GetStandalone(XmlDeclaration/*!*/ self) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    return null;
                }

                Object value;
                (data.Attr as Hash).TryGetValue(_standalone, out value);
                return value;
            }

            [RubyMethod("standalone=")]
            public static void SetStandalone(RubyContext/*!*/ context, XmlDeclaration/*!*/ self, Object/*!*/ standalone) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    data.Attr = new Hash(context);
                }
                (data.Attr as Hash)[_standalone] = standalone;
            }

            [RubyMethod("version")]
            public static Object GetVersion(XmlDeclaration/*!*/ self) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    return null;
                }

                Object value;
                (data.Attr as Hash).TryGetValue(_version, out value);
                return value;
            }

            [RubyMethod("version=")]
            public static void SetVersion(RubyContext/*!*/ context, XmlDeclaration/*!*/ self, Object/*!*/ version) {
                AttributeData data = self._data as AttributeData;
                if (data.AttrIsNull) {
                    data.Attr = new Hash(context);
                }
                (data.Attr as Hash)[_version] = version;
            }
        }

        #endregion

        #region Hpricot::ProcIns

        [RubyClass("ProcIns", Inherits = typeof(BaseElement))]
        public class ProcedureInstruction : BaseElement {
            public ProcedureInstruction(ScannerState state) 
                : this(state.Context) { 
            }

            public ProcedureInstruction(RubyContext context)
                : base(context, new AttributeData()) {
            }
            
            [RubyConstructor]
            public static ProcedureInstruction Allocator(RubyClass/*!*/ self) {
                return new ProcedureInstruction(self.Context);
            }

            protected override MutableString RawString {
                get {
                    return MutableString.CreateAscii(String.Format("<!--{0}-->", GetContent(this)));
                }
            }

            [RubyMethod("content")]
            public static MutableString GetContent(ProcedureInstruction/*!*/ self) {
                return (self._data as AttributeData).Attr as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(ProcedureInstruction/*!*/ self, Object/*!*/ content) {
                (self._data as AttributeData).Attr = content;
            }

            [RubyMethod("target")]
            public static Object GetTarget(ProcedureInstruction/*!*/ self) {
                return self._data.Tag;
            }

            [RubyMethod("target=")]
            public static void SetTarget(ProcedureInstruction/*!*/ self, Object/*!*/ target) {
                self._data.Tag = target;
            }
        }

        #endregion


        #region Hpricot::ParseError

        [RubyClass("ParseError")]
        public class ParserException : SystemException {
            public ParserException(String message) :
                base(message) {
            }
        }

        #endregion
    }
}
