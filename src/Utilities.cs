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

        public static RubyModule GetHpricotModule(RubyContext context) {
            RubyModule hpricotModule;
            if (!context.TryGetModule(typeof(Hpricot), out hpricotModule)) {
                RubyExceptions.CreateNameError("Cannot find module Hpricot");
            }
            return hpricotModule;
        }

        public static Int32? GetBufferSize(RubyContext context) {
            return GetBufferSize(GetHpricotModule(context));
        }

        public static Int32? GetBufferSize(RubyModule hpricotModule) {
            Object bufferSize;
            if (hpricotModule.TryGetClassVariable("@@buffer_size", out bufferSize)) {
                return (int)bufferSize;
            }
            return null;
        }

        public static void SetBufferSize(RubyContext context, Int32 bufferSize) {
            SetBufferSize(GetHpricotModule(context), bufferSize);
        }

        public static void SetBufferSize(RubyModule hpricotModule, Int32 bufferSize) {
            hpricotModule.SetClassVariable("@@buffer_size", bufferSize);
        }
    }
}
