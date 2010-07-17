using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyModule("Hpricot")]
    public static class Hpricot {
        [RubyConstant("ProcInsParse")]
        public static readonly RubyRegex ProcInsParse = HpricotScanner.ProcInsParse;

        [RubyMethod("scan", RubyMethodAttributes.PublicSingleton)]
        public static Object Scan(ConversionStorage<MutableString>/*!*/ toMutableStringStorage, RespondToStorage/*!*/ respondsTo, 
            BinaryOpStorage/*!*/ readIOStorage, BlockParam block, RubyModule/*!*/ self, Object/*!*/ source, Hash/*!*/ options) {

            Object elementContent;
            if (!self.TryGetConstant(null, "ElementContent", out elementContent) && !(elementContent is Hash)) {
                throw new Exception("Hpricot::ElementContent is missing or it is not an Hash");
            }
            var scanner = new HpricotScanner(toMutableStringStorage, readIOStorage, block);
            return scanner.Scan(source, options, elementContent as Hash);
        }

        [RubyMethod("css", RubyMethodAttributes.PublicSingleton)]
        public static Object Css(RubyContext/*!*/ context, BlockParam/*!*/ block, RubyModule/*!*/ self) {
            return null;
        }

        [RubyMethod("buffer_size", RubyMethodAttributes.PublicSingleton)]
        public static Int32? GetBufferSize(RubyModule/*!*/ self) {
            Object bufferSize;
            if (self.TryGetClassVariable("@@buffer_size", out bufferSize)) {
                return (int) bufferSize;
            }
            return null;
        }

        [RubyMethod("buffer_size=", RubyMethodAttributes.PublicSingleton)]
        public static void SetBufferSize(RubyModule/*!*/ self, Int32 bufferSize) {
            self.SetClassVariable("@@buffer_size", bufferSize);
        }
    }
}
