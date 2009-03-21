[assembly: IronRuby.Runtime.RubyLibraryAttribute(typeof(IronRuby.Libraries.Hpricot.HpricotLibraryInitializer))]

namespace IronRuby.Libraries.Hpricot {
    public sealed class HpricotLibraryInitializer : IronRuby.Builtins.LibraryInitializer {
        protected override void LoadModules() {
            IronRuby.Builtins.RubyClass classRef0 = GetClass(typeof(System.Object));
            IronRuby.Builtins.RubyClass classRef1 = GetClass(typeof(System.SystemException));
            
            
            IronRuby.Builtins.RubyModule def1 = DefineGlobalModule("Hpricot", typeof(IronRuby.Libraries.Hpricot.Hpricot), true, null, LoadHpricot_Class, LoadHpricot_Constants, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def2 = DefineClass("Hpricot::BaseEle", typeof(IronRuby.Libraries.Hpricot.Hpricot.BaseEle), true, classRef0, LoadHpricot__BaseEle_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def6 = DefineClass("Hpricot::Doc", typeof(IronRuby.Libraries.Hpricot.Hpricot.Doc), true, classRef0, LoadHpricot__Doc_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def10 = DefineClass("Hpricot::ParseError", typeof(IronRuby.Libraries.Hpricot.Hpricot.ParserException), true, classRef1, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            ExtendModule(typeof(IronRuby.Builtins.MutableString), LoadIronRuby__Builtins__MutableString_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def4 = DefineClass("Hpricot::CData", typeof(IronRuby.Libraries.Hpricot.Hpricot.CData), true, def2, LoadHpricot__CData_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def5 = DefineClass("Hpricot::Comment", typeof(IronRuby.Libraries.Hpricot.Hpricot.Comment), true, def2, LoadHpricot__Comment_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def7 = DefineClass("Hpricot::DocType", typeof(IronRuby.Libraries.Hpricot.Hpricot.DocType), true, def2, LoadHpricot__DocType_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def8 = DefineClass("Hpricot::Elem", typeof(IronRuby.Libraries.Hpricot.Hpricot.Elem), true, def2, LoadHpricot__Elem_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def9 = DefineClass("Hpricot::ETag", typeof(IronRuby.Libraries.Hpricot.Hpricot.ETag), true, def2, LoadHpricot__ETag_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def11 = DefineClass("Hpricot::ProcIns", typeof(IronRuby.Libraries.Hpricot.Hpricot.ProcIns), true, def2, LoadHpricot__ProcIns_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def12 = DefineClass("Hpricot::XMLDecl", typeof(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl), true, def2, LoadHpricot__XMLDecl_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def3 = DefineClass("Hpricot::BogusETag", typeof(IronRuby.Libraries.Hpricot.Hpricot.BogusETag), true, def9, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            def1.SetConstant("BaseEle", def2);
            def1.SetConstant("Doc", def6);
            def1.SetConstant("ParseError", def10);
            def1.SetConstant("CData", def4);
            def1.SetConstant("Comment", def5);
            def1.SetConstant("DocType", def7);
            def1.SetConstant("Elem", def8);
            def1.SetConstant("ETag", def9);
            def1.SetConstant("ProcIns", def11);
            def1.SetConstant("XMLDecl", def12);
            def1.SetConstant("BogusETag", def3);
        }
        
        private static void LoadHpricot_Constants(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.SetConstant("ProcInsParse", IronRuby.Libraries.Hpricot.Hpricot.ProcInsParse);
            
        }
        
        private static void LoadHpricot_Class(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("buffer_size", 0x21, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Nullable<System.Int32>>(IronRuby.Libraries.Hpricot.Hpricot.GetBufferSize)
            );
            
            module.DefineLibraryMethod("buffer_size=", 0x21, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Int32>(IronRuby.Libraries.Hpricot.Hpricot.SetBufferSize)
            );
            
            module.DefineLibraryMethod("css", 0x21, 
                new System.Func<IronRuby.Runtime.RubyContext, IronRuby.Runtime.BlockParam, IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Css)
            );
            
            module.DefineLibraryMethod("scan", 0x21, 
                new System.Func<IronRuby.Runtime.ConversionStorage<IronRuby.Builtins.MutableString>, IronRuby.Runtime.RespondToStorage, IronRuby.Runtime.RubyContext, IronRuby.Runtime.BlockParam, IronRuby.Builtins.RubyModule, System.Object, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Scan)
            );
            
        }
        
        private static void LoadHpricot__BaseEle_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("parent", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.BaseEle.GetParent)
            );
            
            module.DefineLibraryMethod("parent=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.BaseEle.SetParent)
            );
            
            module.DefineLibraryMethod("raw_string", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.BaseEle.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__CData_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.CData.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.CData.SetContent)
            );
            
        }
        
        private static void LoadHpricot__Comment_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Comment.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Comment.SetContent)
            );
            
        }
        
        private static void LoadHpricot__Doc_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("children", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Doc.GetChildren)
            );
            
            module.DefineLibraryMethod("children=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Doc.SetChildren)
            );
            
        }
        
        private static void LoadHpricot__DocType_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("public_id", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocType.GetPublicId)
            );
            
            module.DefineLibraryMethod("public_id=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocType.SetPublicId)
            );
            
            module.DefineLibraryMethod("system_id", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocType.GetSystemId)
            );
            
            module.DefineLibraryMethod("system_id=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocType.SetSystemId)
            );
            
            module.DefineLibraryMethod("target", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocType.GetTarget)
            );
            
            module.DefineLibraryMethod("target=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocType.SetTarget)
            );
            
        }
        
        private static void LoadHpricot__Elem_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("children", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.GetChildren)
            );
            
            module.DefineLibraryMethod("children=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.SetChildren)
            );
            
            module.DefineLibraryMethod("clear_raw", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.Elem.GetClearRaw)
            );
            
            module.DefineLibraryMethod("etag", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.GetEtag)
            );
            
            module.DefineLibraryMethod("etag=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.SetEtag)
            );
            
            module.DefineLibraryMethod("name", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.GetName)
            );
            
            module.DefineLibraryMethod("name=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.SetName)
            );
            
            module.DefineLibraryMethod("raw_attributes", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.GetRawAttributes)
            );
            
            module.DefineLibraryMethod("raw_attributes=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Elem.SetRawAttributes)
            );
            
            module.DefineLibraryMethod("raw_string", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.Elem.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__ETag_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("clear_raw", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.ETag.GetClearRaw)
            );
            
            module.DefineLibraryMethod("name", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ETag.GetName)
            );
            
            module.DefineLibraryMethod("name=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ETag.SetName)
            );
            
            module.DefineLibraryMethod("raw_string", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.ETag.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__ProcIns_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcIns.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcIns.SetContent)
            );
            
            module.DefineLibraryMethod("target", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcIns.GetTarget)
            );
            
            module.DefineLibraryMethod("target=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcIns.SetTarget)
            );
            
        }
        
        private static void LoadHpricot__XMLDecl_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("encoding", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl.GetEncoding)
            );
            
            module.DefineLibraryMethod("encoding=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl.SetEncoding)
            );
            
            module.DefineLibraryMethod("standalone", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl.GetStandalone)
            );
            
            module.DefineLibraryMethod("standalone=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl.SetStandalone)
            );
            
            module.DefineLibraryMethod("version", 0x11, 
                new System.Func<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl.GetVersion)
            );
            
            module.DefineLibraryMethod("version=", 0x11, 
                new System.Action<IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XMLDecl.SetVersion)
            );
            
        }
        
        private static void LoadIronRuby__Builtins__MutableString_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("fast_xs", 0x11, 
                new System.Func<IronRuby.Runtime.RubyContext, IronRuby.Builtins.MutableString, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.MutableStringOps.FastXs)
            );
            
        }
        
    }
}

