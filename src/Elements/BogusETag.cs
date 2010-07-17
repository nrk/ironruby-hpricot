using System;
using System.Text;
using System.Diagnostics;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("BogusETag", Inherits = typeof(ETag), DefineIn = typeof(Hpricot))]
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
}
