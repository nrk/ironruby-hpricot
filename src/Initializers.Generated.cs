#pragma warning disable 169 // mcs: unused private method
[assembly: IronRuby.Runtime.RubyLibraryAttribute(typeof(IronRuby.Hpricot.HpricotLibraryInitializer))]

namespace IronRuby.Hpricot {
    using System;
    using Microsoft.Scripting.Utils;
    
    public sealed class HpricotLibraryInitializer : IronRuby.Builtins.LibraryInitializer {
        protected override void LoadModules() {
            IronRuby.Builtins.RubyClass classRef0 = GetClass(typeof(System.Object));
            IronRuby.Builtins.RubyClass classRef1 = GetClass(typeof(System.SystemException));
            
            
            IronRuby.Builtins.RubyModule def1 = DefineGlobalModule("Hpricot", typeof(IronRuby.Hpricot.Hpricot), 0x00000008, null, LoadHpricot_Class, LoadHpricot_Constants, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def2 = DefineClass("Hpricot::BaseEle", typeof(IronRuby.Hpricot.BaseElement), 0x00000008, classRef0, LoadHpricot__BaseEle_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def6 = DefineClass("Hpricot::Doc", typeof(IronRuby.Hpricot.Document), 0x00000008, classRef0, LoadHpricot__Doc_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.Document>(IronRuby.Hpricot.Document.Allocator)
            );
            IronRuby.Builtins.RubyClass def10 = DefineClass("Hpricot::ParseError", typeof(IronRuby.Hpricot.ParserException), 0x00000008, classRef1, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            ExtendModule(typeof(IronRuby.Builtins.MutableString), 0x00000000, LoadIronRuby__Builtins__MutableString_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray);
            IronRuby.Builtins.RubyClass def4 = DefineClass("Hpricot::CData", typeof(IronRuby.Hpricot.CData), 0x00000008, def2, LoadHpricot__CData_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.CData>(IronRuby.Hpricot.CData.Allocator)
            );
            IronRuby.Builtins.RubyClass def5 = DefineClass("Hpricot::Comment", typeof(IronRuby.Hpricot.Comment), 0x00000008, def2, LoadHpricot__Comment_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.Comment>(IronRuby.Hpricot.Comment.Allocator)
            );
            IronRuby.Builtins.RubyClass def7 = DefineClass("Hpricot::DocType", typeof(IronRuby.Hpricot.DocumentType), 0x00000008, def2, LoadHpricot__DocType_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.DocumentType>(IronRuby.Hpricot.DocumentType.Allocator)
            );
            IronRuby.Builtins.RubyClass def8 = DefineClass("Hpricot::Elem", typeof(IronRuby.Hpricot.Element), 0x00000008, def2, LoadHpricot__Elem_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.Element>(IronRuby.Hpricot.Element.Allocator)
            );
            IronRuby.Builtins.RubyClass def9 = DefineClass("Hpricot::ETag", typeof(IronRuby.Hpricot.ETag), 0x00000008, def2, LoadHpricot__ETag_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.ETag>(IronRuby.Hpricot.ETag.Allocator)
            );
            IronRuby.Builtins.RubyClass def11 = DefineClass("Hpricot::ProcIns", typeof(IronRuby.Hpricot.ProcedureInstruction), 0x00000008, def2, LoadHpricot__ProcIns_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.ProcedureInstruction>(IronRuby.Hpricot.ProcedureInstruction.Allocator)
            );
            IronRuby.Builtins.RubyClass def12 = DefineClass("Hpricot::Text", typeof(IronRuby.Hpricot.Text), 0x00000008, def2, LoadHpricot__Text_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.Text>(IronRuby.Hpricot.Text.Allocator)
            );
            IronRuby.Builtins.RubyClass def13 = DefineClass("Hpricot::XMLDecl", typeof(IronRuby.Hpricot.XmlDeclaration), 0x00000008, def2, LoadHpricot__XMLDecl_Instance, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.XmlDeclaration>(IronRuby.Hpricot.XmlDeclaration.Allocator)
            );
            IronRuby.Builtins.RubyClass def3 = DefineClass("Hpricot::BogusETag", typeof(IronRuby.Hpricot.BogusETag), 0x00000008, def9, null, null, null, IronRuby.Builtins.RubyModule.EmptyArray, 
                new Func<IronRuby.Builtins.RubyClass, IronRuby.Hpricot.BogusETag>(IronRuby.Hpricot.BogusETag.Allocator)
            );
            SetConstant(def1, "BaseEle", def2);
            SetConstant(def1, "Doc", def6);
            SetConstant(def1, "ParseError", def10);
            SetConstant(def1, "CData", def4);
            SetConstant(def1, "Comment", def5);
            SetConstant(def1, "DocType", def7);
            SetConstant(def1, "Elem", def8);
            SetConstant(def1, "ETag", def9);
            SetConstant(def1, "ProcIns", def11);
            SetConstant(def1, "Text", def12);
            SetConstant(def1, "XMLDecl", def13);
            SetConstant(def1, "BogusETag", def3);
        }
        
        private static void LoadHpricot_Constants(IronRuby.Builtins.RubyModule/*!*/ module) {
            SetConstant(module, "ProcInsParse", IronRuby.Hpricot.Hpricot.ProcInsParse);
            
        }
        
        private static void LoadHpricot_Class(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "buffer_size", 0x21, 
                0x00000000U, 
                new Func<IronRuby.Builtins.RubyModule, System.Nullable<System.Int32>>(IronRuby.Hpricot.Hpricot.GetBufferSize)
            );
            
            DefineLibraryMethod(module, "buffer_size=", 0x21, 
                0x00000000U, 
                new Action<IronRuby.Builtins.RubyModule, System.Int32>(IronRuby.Hpricot.Hpricot.SetBufferSize)
            );
            
            DefineLibraryMethod(module, "css", 0x21, 
                0x00000000U, 
                new Func<IronRuby.Runtime.RubyContext, IronRuby.Runtime.BlockParam, IronRuby.Builtins.RubyModule, System.Object>(IronRuby.Hpricot.Hpricot.Css)
            );
            
            DefineLibraryMethod(module, "scan", 0x21, 
                0x00000000U, 
                new Func<IronRuby.Runtime.ConversionStorage<IronRuby.Builtins.MutableString>, IronRuby.Runtime.RespondToStorage, IronRuby.Runtime.BinaryOpStorage, IronRuby.Runtime.BlockParam, IronRuby.Builtins.RubyModule, System.Object, IronRuby.Builtins.Hash, System.Object>(IronRuby.Hpricot.Hpricot.Scan)
            );
            
        }
        
        private static void LoadHpricot__BaseEle_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "parent", 0x11, 
                0x00000000U,
                new Func<IronRuby.Hpricot.BaseElement, IronRuby.Hpricot.IHpricotDataContainer>(IronRuby.Hpricot.BaseElement.GetParent)
            );
            
            DefineLibraryMethod(module, "parent=", 0x11, 
                0x00000000U,
                new Action<IronRuby.Hpricot.BaseElement, IronRuby.Hpricot.IHpricotDataContainer>(IronRuby.Hpricot.BaseElement.SetParent)
            );
            
            DefineLibraryMethod(module, "raw_string", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.BaseElement, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.BaseElement.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__CData_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "content", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.CData, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.CData.GetContent)
            );
            
            DefineLibraryMethod(module, "content=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.CData, System.Object>(IronRuby.Hpricot.CData.SetContent)
            );
            
        }
        
        private static void LoadHpricot__Comment_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "content", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.Comment, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.Comment.GetContent)
            );
            
            DefineLibraryMethod(module, "content=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.Comment, System.Object>(IronRuby.Hpricot.Comment.SetContent)
            );
            
        }
        
        private static void LoadHpricot__Doc_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "children", 0x11, 
                0x00000000U,
                new Func<IronRuby.Hpricot.Document, System.Collections.Generic.IList<Object>>(IronRuby.Hpricot.Document.GetChildren)
            );
            
            DefineLibraryMethod(module, "children=", 0x11, 
                0x00000000U,
                new Action<IronRuby.Hpricot.Document, System.Collections.Generic.IList<Object>>(IronRuby.Hpricot.Document.SetChildren)
            );
            
        }
        
        private static void LoadHpricot__DocType_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "public_id", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.DocumentType, System.Object>(IronRuby.Hpricot.DocumentType.GetPublicId)
            );
            
            DefineLibraryMethod(module, "public_id=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Runtime.RubyContext, IronRuby.Hpricot.DocumentType, System.Object>(IronRuby.Hpricot.DocumentType.SetPublicId)
            );
            
            DefineLibraryMethod(module, "system_id", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.DocumentType, System.Object>(IronRuby.Hpricot.DocumentType.GetSystemId)
            );
            
            DefineLibraryMethod(module, "system_id=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Runtime.RubyContext, IronRuby.Hpricot.DocumentType, System.Object>(IronRuby.Hpricot.DocumentType.SetSystemId)
            );
            
            DefineLibraryMethod(module, "target", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.DocumentType, System.Object>(IronRuby.Hpricot.DocumentType.GetTarget)
            );
            
            DefineLibraryMethod(module, "target=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.DocumentType, System.Object>(IronRuby.Hpricot.DocumentType.SetTarget)
            );
            
        }
        
        private static void LoadHpricot__Elem_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "children", 0x11, 
                0x00000000U,
                new Func<IronRuby.Hpricot.Element, System.Collections.Generic.IList<Object>>(IronRuby.Hpricot.Element.GetChildren)
            );
            
            DefineLibraryMethod(module, "children=", 0x11, 
                0x00000000U,
                new Action<IronRuby.Hpricot.Element, System.Collections.Generic.IList<Object>>(IronRuby.Hpricot.Element.SetChildren)
            );
            
            DefineLibraryMethod(module, "clear_raw", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.Element, System.Boolean>(IronRuby.Hpricot.Element.ClearRaw)
            );
            
            DefineLibraryMethod(module, "etag", 0x11, 
                0x00000000U,
                new Func<IronRuby.Hpricot.Element, IronRuby.Hpricot.IHpricotDataContainer>(IronRuby.Hpricot.Element.GetEtag)
            );
            
            DefineLibraryMethod(module, "etag=", 0x11, 
                0x00000000U,
                new Action<IronRuby.Hpricot.Element, IronRuby.Hpricot.IHpricotDataContainer>(IronRuby.Hpricot.Element.SetEtag)
            );
            
            DefineLibraryMethod(module, "name", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.Element, System.Object>(IronRuby.Hpricot.Element.GetName)
            );
            
            DefineLibraryMethod(module, "name=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.Element, System.Object>(IronRuby.Hpricot.Element.SetName)
            );
            
            DefineLibraryMethod(module, "raw_attributes", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.Element, System.Object>(IronRuby.Hpricot.Element.GetRawAttributes)
            );
            
            DefineLibraryMethod(module, "raw_attributes=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.Element, System.Object>(IronRuby.Hpricot.Element.SetRawAttributes)
            );
            
            DefineLibraryMethod(module, "raw_string", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.Element, System.Object>(IronRuby.Hpricot.Element.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__ETag_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "clear_raw", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.ETag, System.Boolean>(IronRuby.Hpricot.ETag.ClearRaw)
            );
            
            DefineLibraryMethod(module, "name", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.ETag, System.Object>(IronRuby.Hpricot.ETag.GetName)
            );
            
            DefineLibraryMethod(module, "name=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.ETag, System.Object>(IronRuby.Hpricot.ETag.SetName)
            );
            
            DefineLibraryMethod(module, "raw_string", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.ETag, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.ETag.GetRawString)
            );
            
        }
        
        private static void LoadHpricot__ProcIns_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "content", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.ProcedureInstruction, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.ProcedureInstruction.GetContent)
            );
            
            DefineLibraryMethod(module, "content=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.ProcedureInstruction, System.Object>(IronRuby.Hpricot.ProcedureInstruction.SetContent)
            );
            
            DefineLibraryMethod(module, "target", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.ProcedureInstruction, System.Object>(IronRuby.Hpricot.ProcedureInstruction.GetTarget)
            );
            
            DefineLibraryMethod(module, "target=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.ProcedureInstruction, System.Object>(IronRuby.Hpricot.ProcedureInstruction.SetTarget)
            );
            
        }
        
        private static void LoadHpricot__Text_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "content", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.Text, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.Text.GetContent)
            );
            
            DefineLibraryMethod(module, "content=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Hpricot.Text, System.Object>(IronRuby.Hpricot.Text.SetContent)
            );
            
        }
        
        private static void LoadHpricot__XMLDecl_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "encoding", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.XmlDeclaration, System.Object>(IronRuby.Hpricot.XmlDeclaration.GetEncoding)
            );
            
            DefineLibraryMethod(module, "encoding=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Runtime.RubyContext, IronRuby.Hpricot.XmlDeclaration, System.Object>(IronRuby.Hpricot.XmlDeclaration.SetEncoding)
            );
            
            DefineLibraryMethod(module, "standalone", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.XmlDeclaration, System.Object>(IronRuby.Hpricot.XmlDeclaration.GetStandalone)
            );
            
            DefineLibraryMethod(module, "standalone=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Runtime.RubyContext, IronRuby.Hpricot.XmlDeclaration, System.Object>(IronRuby.Hpricot.XmlDeclaration.SetStandalone)
            );
            
            DefineLibraryMethod(module, "version", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Hpricot.XmlDeclaration, System.Object>(IronRuby.Hpricot.XmlDeclaration.GetVersion)
            );
            
            DefineLibraryMethod(module, "version=", 0x11, 
                0x00000000U, 
                new Action<IronRuby.Runtime.RubyContext, IronRuby.Hpricot.XmlDeclaration, System.Object>(IronRuby.Hpricot.XmlDeclaration.SetVersion)
            );
            
        }
        
        private static void LoadIronRuby__Builtins__MutableString_Instance(IronRuby.Builtins.RubyModule/*!*/ module) {
            DefineLibraryMethod(module, "fast_xs", 0x11, 
                0x00000000U, 
                new Func<IronRuby.Runtime.RubyContext, IronRuby.Builtins.MutableString, IronRuby.Builtins.MutableString>(IronRuby.Hpricot.FastXs.MutableStringOps.FastXs)
            );
            
        }
        
    }
}

