using System;
using System.Text;
using System.Diagnostics;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("Text", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
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
}
