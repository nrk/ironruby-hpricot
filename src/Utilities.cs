using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    public static class Utilities {
        public static MutableString CreateMutableStringFromBuffer(char[] buffer, int raw, int rawlen) { 
            return MutableString.Create(new String(buffer, raw, rawlen), RubyEncoding.Binary);
        }
    }
}
