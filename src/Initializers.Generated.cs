[assembly: IronRuby.Runtime.RubyLibraryAttribute(typeof(IronRuby.Libraries.Hpricot.HpricotLibraryInitializer))]

namespace IronRuby.Libraries.Hpricot {
    using System;
    using Microsoft.Scripting.Utils;
    
    public sealed class HpricotLibraryInitializer : IronRuby.Builtins.LibraryInitializer {
        protected override void LoadModules() {
            IronRuby.Builtins.RubyClass classRef0 = GetClass(typeof(System.SystemException));
            
            
            IronRuby.Builtins.RubyModule def1 = DefineGlobalModule("Hpricot", typeof(IronRuby.Libraries.Hpricot.Hpricot), 0x00000100, null, LoadHpricot_Class, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def2 = DefineClass("Hpricot::ParseError", typeof(IronRuby.Libraries.Hpricot.Hpricot.ParserException), 0x00000100, classRef0, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            ExtendModule(typeof(IronRuby.Builtins.MutableString), 0x00000000, LoadIronRuby__Builtins__MutableString_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            SetConstant(def1, "ParseError", def2);
        }
        
        private static void LoadHpricot_Class(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "buffer_size", 0x21, 
                new Func<IronRuby.Builtins.RubyModule, System.Nullable<System.Int32>>(IronRuby.Libraries.Hpricot.Hpricot.GetBufferSize)
            );
            
            DefineLibraryMethod(module, "buffer_size=", 0x21, 
                new Action<IronRuby.Builtins.RubyModule, System.Int32>(IronRuby.Libraries.Hpricot.Hpricot.SetBufferSize)
            );
            
            DefineLibraryMethod(module, "scan", 0x21, 
                new Func<IronRuby.Runtime.ConversionStorage<IronRuby.Builtins.MutableString>, IronRuby.Runtime.RespondToStorage, IronRuby.Runtime.BinaryOpStorage, IronRuby.Runtime.BlockParam, IronRuby.Builtins.RubyModule, System.Object, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Scan)
            );
            
        }
        
        private static void LoadIronRuby__Builtins__MutableString_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "fast_xs", 0x11, 
                new Func<IronRuby.Runtime.RubyContext, IronRuby.Builtins.MutableString, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.MutableStringOps.FastXs)
            );
            
        }
        
    }
}

