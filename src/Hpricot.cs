using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Libraries.Hpricot {

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
            RubyContext/*!*/ context, BlockParam block, RubyModule/*!*/ self, Object/*!*/ source) {

            //NOTE: block can be null as of Hpricot 0.7, see HpricotScanner.ELE
            HpricotScanner scanner = new HpricotScanner(respondsTo, toMutableStringStorage, context, block);
            return scanner.Scan(source);
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
            private ElementData _data;

            public Document() : this(new ElementData()) { }

            public Document(ElementData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static Document Allocator(RubyClass/*!*/ self) {
                return new Document();
            }

            [RubyMethod("children")]
            public static Object GetChildren(Document/*!*/ self) {
                return self._data.children;
            }

            [RubyMethod("children=")]
            public static void SetChildren(Document/*!*/ self, Object/*!*/ children) {
                self._data.children = children;
            }
        }

        #endregion

        #region Hpricot::BaseEle

        [RubyClass("BaseEle")]
        public class BaseElement : IHpricotDataContainer {
            private BasicData _data;

            public BaseElement() : this(new BasicData()) { }

            public BaseElement(BasicData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static BaseElement Allocator(RubyClass/*!*/ self) {
                return new BaseElement();
            }

            [RubyMethod("raw_string")]
            public static MutableString GetRawString(BaseElement/*!*/ self) {
                return self._data.tag as MutableString;
            }

            [RubyMethod("parent")]
            public static Object GetParent(BaseElement/*!*/ self) {
                return self._data.parent;
            }

            [RubyMethod("parent=")]
            public static void SetParent(BaseElement/*!*/ self, Object/*!*/ parent) {
                self._data.parent = parent;
            }
        }

        #endregion

        #region Hpricot::CData 

        [RubyClass("CData", Inherits = typeof(BaseElement))]
        public class CData : IHpricotDataContainer {
            private BasicData _data;

            public CData() : this(new BasicData()) { }

            public CData(BasicData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static CData Allocator(RubyClass/*!*/ self) {
                return new CData();
            }

            [RubyMethod("content")]
            public static MutableString GetContent(CData/*!*/ self) {
                return self._data.tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(CData/*!*/ self, Object/*!*/ content) {
                self._data.tag = content;
            }
        }

        #endregion

        #region Hpricot::Comment

        [RubyClass("Comment", Inherits = typeof(BaseElement))]
        public class Comment : IHpricotDataContainer {
            private BasicData _data;

            public Comment() : this(new BasicData()) { }

            public Comment(BasicData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static Comment Allocator(RubyClass/*!*/ self) {
                return new Comment();
            }

            [RubyMethod("content")]
            public static MutableString GetContent(Comment/*!*/ self) {
                return self._data.tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(Comment/*!*/ self, Object/*!*/ content) {
                self._data.tag = content;
            }
        }

        #endregion

        #region Hpricot::DocType

        [RubyClass("DocType", Inherits = typeof(BaseElement))]
        public class DocumentType : IHpricotDataContainer {
            private AttributeData _data;

            public DocumentType() : this(new AttributeData()) { }

            public DocumentType(AttributeData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static DocumentType Allocator(RubyClass/*!*/ self) {
                return new DocumentType();
            }

            [RubyMethod("target")]
            public static Object GetTarget(DocumentType/*!*/ self) {
                return self._data.tag;
            }

            [RubyMethod("target=")]
            public static void SetTarget(DocumentType/*!*/ self, Object/*!*/ target) {
                self._data.tag = target;
            }

            [RubyMethod("public_id")]
            public static Object GetPublicId(DocumentType/*!*/ self) {
                return (self._data.attr as Hash)["public_id"];
            }

            [RubyMethod("public_id=")]
            public static void SetPublicId(DocumentType/*!*/ self, Object/*!*/ publicId) {
                (self._data.attr as Hash)["public_id"] = publicId;
            }

            [RubyMethod("system_id")]
            public static Object GetSystemId(DocumentType/*!*/ self) {
                return (self._data.attr as Hash)["system_id"];
            }

            [RubyMethod("system_id=")]
            public static void SetSystemId(DocumentType/*!*/ self, Object/*!*/ systemId) {
                (self._data.attr as Hash)["system_id"] = systemId;
            }
        }

        #endregion

        #region Hpricot::Elem

        [RubyClass("Elem", Inherits = typeof(BaseElement))]
        public class Element : IHpricotDataContainer {
            private ElementData _data;

            public Element() : this(new ElementData()) { }

            public Element(ElementData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static Element Allocator(RubyClass/*!*/ self) {
                return new Element();
            }

            [RubyMethod("raw_string")]
            public static MutableString GetRawString(Element/*!*/ self) {
                return self._data.tag as MutableString;
            }

            [RubyMethod("clear_raw")]
            public static bool ClearRaw(Element/*!*/ self) {
                self._data.tag = null;
                return true;
            }

            [RubyMethod("raw_attributes")]
            public static Object GetRawAttributes(Element/*!*/ self) {
                return self._data.attr;
            }

            [RubyMethod("raw_attributes=")]
            public static void SetRawAttributes(Element/*!*/ self, Object/*!*/ rawAttributes) {
                self._data.attr = rawAttributes;
            }

            [RubyMethod("children")]
            public static Object GetChildren(Element/*!*/ self) {
                return self._data.children;
            }

            [RubyMethod("children=")]
            public static void SetChildren(Element/*!*/ self, Object/*!*/ children) {
                self._data.children = children;
            }

            [RubyMethod("etag")]
            public static Object GetEtag(Element/*!*/ self) {
                return self._data.etag;
            }

            [RubyMethod("etag=")]
            public static void SetEtag(Element/*!*/ self, Object/*!*/ etag) {
                self._data.etag = etag;
            }

            [RubyMethod("name")]
            public static Object GetName(Element/*!*/ self) {
                return self._data.tag;
            }

            [RubyMethod("name=")]
            public static void SetName(Element/*!*/ self, Object/*!*/ name) {
                self._data.tag = name;
            }
        }

        #endregion
        
        #region Hpricot::ETag

        [RubyClass("ETag", Inherits = typeof(BaseElement))]
        public class ETag : IHpricotDataContainer {
            protected AttributeData _data;

            public ETag() : this(new AttributeData()) { }

            public ETag(AttributeData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static ETag Allocator(RubyClass/*!*/ self) {
                return new ETag();
            }

            [RubyMethod("raw_string")]
            public static MutableString GetRawString(ETag/*!*/ self) {
                // TODO: hmm, I'm not really sure of this...
                return self._data.attr as MutableString;
            }

            [RubyMethod("clear_raw")]
            public static bool ClearRaw(ETag/*!*/ self) {
                self._data.attr = null;
                return true;
            }

            [RubyMethod("name")]
            public static Object GetName(ETag/*!*/ self) {
                return self._data.tag;
            }

            [RubyMethod("name=")]
            public static void SetName(ETag/*!*/ self, Object/*!*/ name) {
                self._data.tag = name;
            }
        }

        #endregion

        #region Hpricot::BogusETag

        [RubyClass("BogusETag", Inherits = typeof(ETag))]
        public class BogusETag : ETag {
            [RubyConstructor]
            public static new BogusETag Allocator(RubyClass/*!*/ self) {
                return new BogusETag();
            }
        }

        #endregion
        
        #region Hpricot::Text

        [RubyClass("Text", Inherits = typeof(BaseElement))]
        public class Text : IHpricotDataContainer { 
            private BasicData _data;

            public Text() : this(new BasicData()) { }

            public Text(BasicData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static Text Allocator(RubyClass/*!*/ self) {
                return new Text();
            }

            [RubyMethod("content")]
            public static MutableString GetContent(Text/*!*/ self) {
                return self._data.tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(Text/*!*/ self, Object/*!*/ content) {
                self._data.tag = content;
            }
        }

        #endregion

        #region Hpricot::XMLDecl

        [RubyClass("XMLDecl", Inherits = typeof(BaseElement))]
        public class XmlDeclaration : IHpricotDataContainer {
            private AttributeData _data;

            public XmlDeclaration() : this(new AttributeData()) { }

            public XmlDeclaration(AttributeData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static XmlDeclaration Allocator(RubyClass/*!*/ self) {
                return new XmlDeclaration();
            }

            [RubyMethod("encoding")]
            public static Object GetEncoding(XmlDeclaration/*!*/ self) {
                return (self._data.attr as Hash)["encoding"];
            }

            [RubyMethod("encoding=")]
            public static void SetEncoding(XmlDeclaration/*!*/ self, Object/*!*/ encoding) {
                (self._data.attr as Hash)["encoding"] = encoding;
            }

            [RubyMethod("standalone")]
            public static Object GetStandalone(XmlDeclaration/*!*/ self) {
                return (self._data.attr as Hash)["standalone"];
            }

            [RubyMethod("standalone=")]
            public static void SetStandalone(XmlDeclaration/*!*/ self, Object/*!*/ standalone) {
                (self._data.attr as Hash)["standalone"] = standalone;
            }

            [RubyMethod("version")]
            public static Object GetVersion(XmlDeclaration/*!*/ self) {
                return (self._data.attr as Hash)["version"];
            }

            [RubyMethod("version=")]
            public static void SetVersion(XmlDeclaration/*!*/ self, Object/*!*/ version) {
                (self._data.attr as Hash)["version"] = version;
            }
        }

        #endregion

        #region Hpricot::ProcIns

        [RubyClass("ProcIns", Inherits = typeof(BaseElement))]
        public class ProcedureInstruction : IHpricotDataContainer {
            private AttributeData _data;

            public ProcedureInstruction() : this(new AttributeData()) { }

            public ProcedureInstruction(AttributeData data) {
                _data = data;
            }

            public T GetData<T>() where T : BasicData {
                return _data as T;
            }

            [RubyConstructor]
            public static ProcedureInstruction Allocator(RubyClass/*!*/ self) {
                return new ProcedureInstruction();
            }

            [RubyMethod("content")]
            public static MutableString GetContent(ProcedureInstruction/*!*/ self) {
                return self._data.tag as MutableString;
            }

            [RubyMethod("content=")]
            public static void SetContent(ProcedureInstruction/*!*/ self, Object/*!*/ content) {
                self._data.tag = content;
            }

            [RubyMethod("target")]
            public static Object GetTarget(ProcedureInstruction/*!*/ self) {
                return self._data.attr;
            }

            [RubyMethod("target=")]
            public static void SetTarget(ProcedureInstruction/*!*/ self, Object/*!*/ target) {
                self._data.attr = target;
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
