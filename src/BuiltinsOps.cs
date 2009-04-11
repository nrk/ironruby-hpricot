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
            // NOTE: we need to convert self to an UTF-8 System::String but self.ToString() returns 
            //       an ASCII-encoded string because self is binary.
            String utf8String = Encoding.UTF8.GetString(self.ToByteArray());
            StringBuilder builder = new StringBuilder((int)(utf8String.Length * 1.5));
            Entities.XML.Escape(builder, utf8String);
            return MutableString.Create(builder.ToString());
        }
    }
}
