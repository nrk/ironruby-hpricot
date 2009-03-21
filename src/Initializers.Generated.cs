[assembly: IronRuby.Runtime.RubyLibraryAttribute(typeof(IronRuby.Libraries.Hpricot.HpricotLibraryInitializer))]

namespace IronRuby.Libraries.Hpricot {
    public sealed class HpricotLibraryInitializer : IronRuby.Builtins.LibraryInitializer {
        protected override void LoadModules() {
            IronRuby.Builtins.RubyClass classRef0 = GetClass(typeof(System.Object));
            IronRuby.Builtins.RubyClass classRef1 = GetClass(typeof(System.SystemException));
            
            
            IronRuby.Builtins.RubyModule def1 = DefineGlobalModule("Hpricot", typeof(IronRuby.Libraries.Hpricot.Hpricot), true, null, LoadHpricot_Class, LoadHpricot_Constants, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def2 = DefineClass("Hpricot::BaseEle", typeof(IronRuby.Libraries.Hpricot.Hpricot.BaseElement), true, classRef0, LoadHpricot__BaseEle_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.BaseElement>(IronRuby.Libraries.Hpricot.Hpricot.BaseElement.Allocator)
            );
            IronRuby.Builtins.RubyClass def6 = DefineClass("Hpricot::Doc", typeof(IronRuby.Libraries.Hpricot.Hpricot.Document), true, classRef0, LoadHpricot__Doc_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.Document>(IronRuby.Libraries.Hpricot.Hpricot.Document.Allocator)
            );
            IronRuby.Builtins.RubyClass def10 = DefineClass("Hpricot::ParseError", typeof(IronRuby.Libraries.Hpricot.Hpricot.ParserException), true, classRef1, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            ExtendModule(typeof(IronRuby.Builtins.MutableString), LoadIronRuby__Builtins__MutableString_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def4 = DefineClass("Hpricot::CData", typeof(IronRuby.Libraries.Hpricot.Hpricot.CData), true, def2, LoadHpricot__CData_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.CData>(IronRuby.Libraries.Hpricot.Hpricot.CData.Allocator)
            );
            IronRuby.Builtins.RubyClass def5 = DefineClass("Hpricot::Comment", typeof(IronRuby.Libraries.Hpricot.Hpricot.Comment), true, def2, LoadHpricot__Comment_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.Comment>(IronRuby.Libraries.Hpricot.Hpricot.Comment.Allocator)
            );
            IronRuby.Builtins.RubyClass def7 = DefineClass("Hpricot::DocType", typeof(IronRuby.Libraries.Hpricot.Hpricot.DocumentType), true, def2, LoadHpricot__DocType_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.DocumentType>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.Allocator)
            );
            IronRuby.Builtins.RubyClass def8 = DefineClass("Hpricot::Elem", typeof(IronRuby.Libraries.Hpricot.Hpricot.Element), true, def2, LoadHpricot__Elem_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.Element>(IronRuby.Libraries.Hpricot.Hpricot.Element.Allocator)
            );
            IronRuby.Builtins.RubyClass def9 = DefineClass("Hpricot::ETag", typeof(IronRuby.Libraries.Hpricot.Hpricot.ETag), true, def2, LoadHpricot__ETag_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.ETag>(IronRuby.Libraries.Hpricot.Hpricot.ETag.Allocator)
            );
            IronRuby.Builtins.RubyClass def11 = DefineClass("Hpricot::ProcIns", typeof(IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction), true, def2, LoadHpricot__ProcIns_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction>(IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction.Allocator)
            );
            IronRuby.Builtins.RubyClass def12 = DefineClass("Hpricot::Text", typeof(IronRuby.Libraries.Hpricot.Hpricot.Text), true, def2, LoadHpricot__Text_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.Text>(IronRuby.Libraries.Hpricot.Hpricot.Text.Allocator)
            );
            IronRuby.Builtins.RubyClass def13 = DefineClass("Hpricot::XMLDecl", typeof(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration), true, def2, LoadHpricot__XMLDecl_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.Allocator)
            );
            IronRuby.Builtins.RubyClass def3 = DefineClass("Hpricot::BogusETag", typeof(IronRuby.Libraries.Hpricot.Hpricot.BogusETag), true, def9, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new System.Func<IronRuby.Builtins.RubyClass, IronRuby.Libraries.Hpricot.Hpricot.BogusETag>(IronRuby.Libraries.Hpricot.Hpricot.BogusETag.Allocator)
            );
            def1.SetConstant("BaseEle", def2);
            def1.SetConstant("Doc", def6);
            def1.SetConstant("ParseError", def10);
            def1.SetConstant("CData", def4);
            def1.SetConstant("Comment", def5);
            def1.SetConstant("DocType", def7);
            def1.SetConstant("Elem", def8);
            def1.SetConstant("ETag", def9);
            def1.SetConstant("ProcIns", def11);
            def1.SetConstant("Text", def12);
            def1.SetConstant("XMLDecl", def13);
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
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.BaseElement, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.BaseElement.GetParent)
            );
            
            module.DefineLibraryMethod("parent=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.BaseElement, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.BaseElement.SetParent)
            );
            
            module.DefineLibraryMethod("raw_string", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.BaseElement, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.BaseElement.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__CData_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.CData, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.CData.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.CData, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.CData.SetContent)
            );
            
        }
        
        private static void LoadHpricot__Comment_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Comment, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.Comment.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Comment, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Comment.SetContent)
            );
            
        }
        
        private static void LoadHpricot__Doc_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("children", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Document, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Document.GetChildren)
            );
            
            module.DefineLibraryMethod("children=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Document, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Document.SetChildren)
            );
            
        }
        
        private static void LoadHpricot__DocType_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("public_id", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.DocumentType, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.GetPublicId)
            );
            
            module.DefineLibraryMethod("public_id=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.DocumentType, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.SetPublicId)
            );
            
            module.DefineLibraryMethod("system_id", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.DocumentType, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.GetSystemId)
            );
            
            module.DefineLibraryMethod("system_id=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.DocumentType, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.SetSystemId)
            );
            
            module.DefineLibraryMethod("target", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.DocumentType, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.GetTarget)
            );
            
            module.DefineLibraryMethod("target=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.DocumentType, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.DocumentType.SetTarget)
            );
            
        }
        
        private static void LoadHpricot__Elem_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("children", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.GetChildren)
            );
            
            module.DefineLibraryMethod("children=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.SetChildren)
            );
            
            module.DefineLibraryMethod("clear_raw", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Boolean>(IronRuby.Libraries.Hpricot.Hpricot.Element.ClearRaw)
            );
            
            module.DefineLibraryMethod("etag", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.GetEtag)
            );
            
            module.DefineLibraryMethod("etag=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.SetEtag)
            );
            
            module.DefineLibraryMethod("name", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.GetName)
            );
            
            module.DefineLibraryMethod("name=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.SetName)
            );
            
            module.DefineLibraryMethod("raw_attributes", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.GetRawAttributes)
            );
            
            module.DefineLibraryMethod("raw_attributes=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Element, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Element.SetRawAttributes)
            );
            
            module.DefineLibraryMethod("raw_string", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Element, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.Element.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__ETag_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("clear_raw", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.ETag, System.Boolean>(IronRuby.Libraries.Hpricot.Hpricot.ETag.ClearRaw)
            );
            
            module.DefineLibraryMethod("name", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.ETag, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ETag.GetName)
            );
            
            module.DefineLibraryMethod("name=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.ETag, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ETag.SetName)
            );
            
            module.DefineLibraryMethod("raw_string", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.ETag, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.ETag.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__ProcIns_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction.SetContent)
            );
            
            module.DefineLibraryMethod("target", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction.GetTarget)
            );
            
            module.DefineLibraryMethod("target=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.ProcedureInstruction.SetTarget)
            );
            
        }
        
        private static void LoadHpricot__Text_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("content", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.Text, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.Hpricot.Text.GetContent)
            );
            
            module.DefineLibraryMethod("content=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.Text, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.Text.SetContent)
            );
            
        }
        
        private static void LoadHpricot__XMLDecl_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("encoding", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.GetEncoding)
            );
            
            module.DefineLibraryMethod("encoding=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.SetEncoding)
            );
            
            module.DefineLibraryMethod("standalone", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.GetStandalone)
            );
            
            module.DefineLibraryMethod("standalone=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.SetStandalone)
            );
            
            module.DefineLibraryMethod("version", 0x11, 
                new System.Func<IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.GetVersion)
            );
            
            module.DefineLibraryMethod("version=", 0x11, 
                new System.Action<IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration, System.Object>(IronRuby.Libraries.Hpricot.Hpricot.XmlDeclaration.SetVersion)
            );
            
        }
        
        private static void LoadIronRuby__Builtins__MutableString_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            module.DefineLibraryMethod("fast_xs", 0x11, 
                new System.Func<IronRuby.Runtime.RubyContext, IronRuby.Builtins.MutableString, IronRuby.Builtins.MutableString>(IronRuby.Libraries.Hpricot.MutableStringOps.FastXs)
            );
            
        }
        
    }
}

