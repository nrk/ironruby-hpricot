[assembly: IronRuby.Runtime.RubyLibraryAttribute(typeof(IronRuby.Libraries.Hpricot.HpricotLibraryInitializer))]

namespace IronRuby.Libraries.Hpricot {
    public sealed class HpricotLibraryInitializer : IronRuby.Builtins.LibraryInitializer {
        protected override void LoadModules() {
            IronRuby.Builtins.RubyClass classRef0 = GetClass(typeof(System.SystemException));
            
            
            IronRuby.Builtins.RubyModule def1 = DefineGlobalModule("Hpricot", typeof(IronRuby.Libraries.Hpricot.Hpricot), 0x00000103, null, LoadHpricot_Class, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def2 = DefineClass("Hpricot::ParseError", typeof(IronRuby.Libraries.Hpricot.Hpricot.ParserException), 0x00000103, classRef0, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            ExtendModule(typeof(IronRuby.Builtins.MutableString), LoadIronRuby__Builtins__MutableString_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            def1.SetConstant("ParseError", def2);
        }
        
        private static void LoadHpricot_Class(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("buffer_size", 0x21, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Nullable<System.Int32>>(IronRuby.Libraries.Hpricot.Hpricot.GetBufferSize)
            );
            
            module.DefineLibraryMethod("buffer_size=", 0x21, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Int32>(IronRuby.Libraries.Hpricot.Hpricot.SetBufferSize)
            );
            
            module.DefineLibraryMethod("scan", 0x21, 
                new System.Func<IronRuby.Runtime.ConversionStorage<IronRuby.Builtins.MutableString>, IronRuby.Runtime.RespondToStorage, IronRuby.Runtime.BinaryOpStorage, IronRuby.Runtime.BlockParam, IronRuby.Builtins.RubyModule, System.Object, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Scan)
            );
            
        }
        
        private static void LoadIronRuby__Builtins__MutableString_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("fast_xs", 0x11, 
                new System.Func<IronRuby.Runtime.RubyContext, IronRuby.Builtins.MutableString, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.MutableStringOps.FastXs)
            );
            
        }
        
    }
}

