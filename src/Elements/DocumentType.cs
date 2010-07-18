using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("DocType", Inherits = typeof(BaseElement), DefineIn=typeof(Hpricot))]
    public class DocumentType : BaseElement {
        private RubySymbol _systemId;
        private RubySymbol _publicId;

        public DocumentType(ScannerState state)
            : this(state.Context) {
        }

        public DocumentType(RubyContext context)
            : base(context, new AttributeData()) {

            _systemId = context.CreateAsciiSymbol("system_id");
            _publicId = context.CreateAsciiSymbol("public_id");
        }

        [RubyConstructor]
        public static DocumentType Allocator(RubyClass/*!*/ self) {
            return new DocumentType(self.Context);
        }

        protected override MutableString RawString {
            get {
                MutableString doctype = MutableString.CreateEmpty();
                doctype.AppendFormat("<!DOCTYPE {0} ", GetTarget(this));

                var data = _data.As<AttributeData>();
                if (!data.AttrIsEmpty) {
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
        public static MutableString GetTarget(DocumentType/*!*/ self) {
            return self._data.Tag;
        }

        [RubyMethod("target=")]
        public static void SetTarget(DocumentType/*!*/ self, MutableString/*!*/ target) {
            self._data.Tag = target;
        }

        [RubyMethod("public_id")]
        public static Object GetPublicId(DocumentType/*!*/ self) {
            var data = self.GetData<AttributeData>();
            if (data.AttrIsEmpty) {
                return null;
            }
            Object value;
            data.AttrAsHash.TryGetValue(self._publicId, out value);
            return value;
        }

        [RubyMethod("public_id=")]
        public static void SetPublicId(RubyContext context/*!*/, DocumentType/*!*/ self, Object/*!*/ publicId) {
            var data = self.GetData<AttributeData>();
            if (data.AttrIsEmpty) {
                data.Attr = new Hash(context);
            }
            data.AttrAsHash[self._publicId] = publicId;
        }

        [RubyMethod("system_id")]
        public static Object GetSystemId(DocumentType/*!*/ self) {
            var data = self.GetData<AttributeData>();
            if (data.AttrIsEmpty) {
                return null;
            }
            Object value;
            data.AttrAsHash.TryGetValue(self._systemId, out value);
            return value;
        }

        [RubyMethod("system_id=")]
        public static void SetSystemId(RubyContext context/*!*/, DocumentType/*!*/ self, Object/*!*/ systemId) {
            var data = self.GetData<AttributeData>();
            if (data.AttrIsEmpty) {
                data.Attr = new Hash(context);
            }
            data.AttrAsHash[self._systemId] = systemId;
        }
    }
}
