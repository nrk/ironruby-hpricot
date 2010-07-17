using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot.FastXs {
    [RubyModule(Extends = typeof(MutableString))]
    public static class MutableStringOps {
        [RubyMethod("fast_xs")]
        public static MutableString FastXs(RubyContext/*!*/ context, MutableString/*!*/ self) {
            //TODO: we are assuming that every string is UTF8, but this is wrong
            String utf8String = Encoding.UTF8.GetString(self.ToByteArray());
            StringBuilder builder = new StringBuilder((int)(utf8String.Length * 1.5));
            Entities.XML.Escape(builder, utf8String);
            return MutableString.CreateAscii(builder.ToString());
        }
    }
}
