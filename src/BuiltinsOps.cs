using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Libraries.Hpricot {
    [RubyModule(Extends = typeof(MutableString))]
    public static class MutableStringOps {
        [RubyMethod("fast_xs")]
        public static MutableString FastXs(RubyContext/*!*/ context, MutableString/*!*/ self) {
            StringBuilder builder = new StringBuilder((int)(self.Length * 1.5));
            Entities.XML.Escape(builder, self.ToString());
            return MutableString.Create(builder.ToString());
        }
    }
}
