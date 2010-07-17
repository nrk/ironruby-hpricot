using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("ParseError", DefineIn = typeof(Hpricot))]
    public class ParserException : SystemException {
        public ParserException(String message) :
            base(message) {
        }
    }
}
