using System;
using System.Text;
using System.Diagnostics;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("XMLDecl", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
    public class XmlDeclaration : BaseElement {
        private RubySymbol _encoding;
        private RubySymbol _standalone;
        private RubySymbol _version;

        public XmlDeclaration(ScannerState state)
            : this(state.Context) {
        }

        public XmlDeclaration(RubyContext context)
            : base(context, new AttributeData()) {

            _encoding = context.CreateAsciiSymbol("encoding");
            _standalone = context.CreateAsciiSymbol("standalone");
            _version = context.CreateAsciiSymbol("version");
        }

        [RubyConstructor]
        public static XmlDeclaration Allocator(RubyClass/*!*/ self) {
            return new XmlDeclaration(self.Context);
        }

        protected override MutableString RawString {
            get {
                MutableString xmldecl = MutableString.CreateEmpty();
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
            (data.Attr as Hash).TryGetValue(self._encoding, out value);
            return value;
        }

        [RubyMethod("encoding=")]
        public static void SetEncoding(RubyContext/*!*/ context, XmlDeclaration/*!*/ self, Object/*!*/ encoding) {
            AttributeData data = self._data as AttributeData;
            if (data.AttrIsNull) {
                data.Attr = new Hash(context);
            }
            (data.Attr as Hash)[self._encoding] = encoding;
        }

        [RubyMethod("standalone")]
        public static Object GetStandalone(XmlDeclaration/*!*/ self) {
            AttributeData data = self._data as AttributeData;
            if (data.AttrIsNull) {
                return null;
            }

            Object value;
            (data.Attr as Hash).TryGetValue(self._standalone, out value);
            return value;
        }

        [RubyMethod("standalone=")]
        public static void SetStandalone(RubyContext/*!*/ context, XmlDeclaration/*!*/ self, Object/*!*/ standalone) {
            AttributeData data = self._data as AttributeData;
            if (data.AttrIsNull) {
                data.Attr = new Hash(context);
            }
            (data.Attr as Hash)[self._standalone] = standalone;
        }

        [RubyMethod("version")]
        public static Object GetVersion(XmlDeclaration/*!*/ self) {
            AttributeData data = self._data as AttributeData;
            if (data.AttrIsNull) {
                return null;
            }

            Object value;
            (data.Attr as Hash).TryGetValue(self._version, out value);
            return value;
        }

        [RubyMethod("version=")]
        public static void SetVersion(RubyContext/*!*/ context, XmlDeclaration/*!*/ self, Object/*!*/ version) {
            AttributeData data = self._data as AttributeData;
            if (data.AttrIsNull) {
                data.Attr = new Hash(context);
            }
            (data.Attr as Hash)[self._version] = version;
        }
    }
}
