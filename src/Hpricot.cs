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
        public static Object Scan(RubyContext/*!*/ context, BlockParam/*!*/ block, RubyModule/*!*/ self, Object/*!*/ source) {
            if (block == null) {
                throw RubyExceptions.NoBlockGiven();
            }
            return new HpricotScanner().Scan(context, block, source);
        }

        [RubyMethod("buffer_size", RubyMethodAttributes.PublicSingleton)]
        public static Int32? GetBufferSize(RubyModule/*!*/ self) {
            return HpricotScanner.BufferSize;
        }

        [RubyMethod("buffer_size=", RubyMethodAttributes.PublicSingleton)]
        public static void SetBufferSize(RubyModule/*!*/ self, Int32 bufferSize) {
            // TODO: thread safety
            HpricotScanner.BufferSize = bufferSize;
        }


        [RubyClass("ParseError")]
        public class ParserException : SystemException {
            public ParserException(String message) :
                base(message) {
            }
        }
    }
}
