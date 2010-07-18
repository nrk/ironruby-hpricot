using System;
using System.Text;
using System.Diagnostics;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("ProcIns", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
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
        public static MutableString GetTarget(ProcedureInstruction/*!*/ self) {
            return self._data.Tag;
        }

        [RubyMethod("target=")]
        public static void SetTarget(ProcedureInstruction/*!*/ self, MutableString/*!*/ target) {
            self._data.Tag = target;
        }
    }
}
