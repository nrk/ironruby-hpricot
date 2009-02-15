using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Libraries.Hpricot {
    [RubyModule("Hpricot")]
    public static class Hpricot {
        [RubyMethod("scan", RubyMethodAttributes.PublicSingleton)]
        public static Object Scan(RespondToStorage/*!*/ respondToStorage, RubyContext/*!*/ context, BlockParam/*!*/ block, RubyModule/*!*/ self, Object/*!*/ source) {
            if (block == null) {
                throw RubyExceptions.NoBlockGiven();
            }
            return new HpricotScanner().Scan(context, block, source);
        }

        [RubyClass("ParseError")]
        public class ParseError : SystemException {
            public ParseError(String message) :
                base(message) {
            }
        }
    }
}
