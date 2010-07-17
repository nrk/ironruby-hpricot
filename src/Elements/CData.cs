using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("CData", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
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
}
