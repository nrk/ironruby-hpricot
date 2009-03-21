using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Libraries.Hpricot {
    [RubyModule("Hpricot")]
    public static class Hpricot {
        #region Hpricot
        
        [RubyConstant("ProcInsParse")]
        public static readonly RubyRegex ProcInsParse = new RubyRegex("\\A<\\?(\\S+)\\s+(.+)", RubyRegexOptions.Multiline);

        [RubyMethod("scan", RubyMethodAttributes.PublicSingleton)]
        public static Object Scan(ConversionStorage<MutableString>/*!*/ toMutableStringStorage, RespondToStorage/*!*/ respondsTo, 
            RubyContext/*!*/ context, BlockParam/*!*/ block, RubyModule/*!*/ self, Object/*!*/ source) {
            if (block == null) {
                throw RubyExceptions.NoBlockGiven();
            }
            HpricotScanner scanner = new HpricotScanner(respondsTo, toMutableStringStorage, context, block);
            return scanner.Scan(source);
        }

        [RubyMethod("css", RubyMethodAttributes.PublicSingleton)]
        public static Object Css(RubyContext/*!*/ context, BlockParam/*!*/ block, RubyModule/*!*/ self) {
            return null;
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

        #endregion

        #region Hpricot::Doc

        [RubyClass("Doc")]
        public static class Doc {
            [RubyMethod("children")]
            public static Object GetChildren(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("children=")]
            public static void SetChildren(RubyModule/*!*/ self, Object children) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::BaseEle

        [RubyClass("BaseEle")]
        public static class BaseEle {
            [RubyMethod("raw_string")]
            public static MutableString GetRawString(RubyModule/*!*/ self) {
                return MutableString.Empty;
            }

            [RubyMethod("parent")]
            public static Object GetParent(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("parent=")]
            public static void SetParent(RubyModule/*!*/ self, Object parent) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::CData 

        [RubyClass("CData", Inherits = typeof(BaseEle))]
        public static class CData {
            [RubyMethod("content")]
            public static Object GetContent(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("content=")]
            public static void SetContent(RubyModule/*!*/ self, Object content) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::Comment

        [RubyClass("Comment", Inherits = typeof(BaseEle))]
        public static class Comment {
            [RubyMethod("content")]
            public static Object GetContent(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("content=")]
            public static void SetContent(RubyModule/*!*/ self, Object content) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::DocType

        [RubyClass("DocType", Inherits = typeof(BaseEle))]
        public static class DocType {
            [RubyMethod("target")]
            public static Object GetTarget(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("target=")]
            public static void SetTarget(RubyModule/*!*/ self, Object target) {
                // ... 
            }

            [RubyMethod("public_id")]
            public static Object GetPublicId(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("public_id=")]
            public static void SetPublicId(RubyModule/*!*/ self, Object publicId) {
                // ... 
            }

            [RubyMethod("system_id")]
            public static Object GetSystemId(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("system_id=")]
            public static void SetSystemId(RubyModule/*!*/ self, Object systemId) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::Elem

        [RubyClass("Elem", Inherits = typeof(BaseEle))]
        public static class Elem {
            [RubyMethod("raw_string")]
            public static MutableString GetRawString(RubyModule/*!*/ self) {
                return MutableString.Empty;
            }

            [RubyMethod("clear_raw")]
            public static MutableString GetClearRaw(RubyModule/*!*/ self) {
                return MutableString.Empty;
            }

            [RubyMethod("raw_attributes")]
            public static Object GetRawAttributes(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("raw_attributes=")]
            public static void SetRawAttributes(RubyModule/*!*/ self, Object rawAttributes) {
                // ... 
            }

            [RubyMethod("children")]
            public static Object GetChildren(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("children=")]
            public static void SetChildren(RubyModule/*!*/ self, Object children) {
                // ... 
            }

            [RubyMethod("etag")]
            public static Object GetEtag(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("etag=")]
            public static void SetEtag(RubyModule/*!*/ self, Object etag) {
                // ... 
            }

            [RubyMethod("name")]
            public static Object GetName(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("name=")]
            public static void SetName(RubyModule/*!*/ self, Object name) {
                // ... 
            }
        }

        #endregion
        
        #region Hpricot::ETag

        [RubyClass("ETag", Inherits = typeof(BaseEle))]
        public static class ETag {
            [RubyMethod("raw_string")]
            public static MutableString GetRawString(RubyModule/*!*/ self) {
                return MutableString.Empty;
            }

            [RubyMethod("clear_raw")]
            public static MutableString GetClearRaw(RubyModule/*!*/ self) {
                return MutableString.Empty;
            }

            [RubyMethod("name")]
            public static Object GetName(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("name=")]
            public static void SetName(RubyModule/*!*/ self, Object name) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::BogusETag

        [RubyClass("BogusETag", Inherits = typeof(ETag))]
        public static class BogusETag { }

        #endregion

        #region Hpricot::XMLDecl

        [RubyClass("XMLDecl", Inherits = typeof(BaseEle))]
        public static class XMLDecl {
            [RubyMethod("encoding")]
            public static Object GetEncoding(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("encoding=")]
            public static void SetEncoding(RubyModule/*!*/ self, Object encoding) {
                // ... 
            }

            [RubyMethod("standalone")]
            public static Object GetStandalone(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("standalone=")]
            public static void SetStandalone(RubyModule/*!*/ self, Object standalone) {
                // ... 
            }

            [RubyMethod("version")]
            public static Object GetVersion(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("version=")]
            public static void SetVersion(RubyModule/*!*/ self, Object version) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::ProcIns

        [RubyClass("ProcIns", Inherits = typeof(BaseEle))]
        public static class ProcIns {
            [RubyMethod("content")]
            public static Object GetContent(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("content=")]
            public static void SetContent(RubyModule/*!*/ self, Object content) {
                // ... 
            }

            [RubyMethod("target")]
            public static Object GetTarget(RubyModule/*!*/ self) {
                return null;
            }

            [RubyMethod("target=")]
            public static void SetTarget(RubyModule/*!*/ self, Object target) {
                // ... 
            }
        }

        #endregion

        #region Hpricot::ParseError

        [RubyClass("ParseError")]
        public class ParserException : SystemException {
            public ParserException(String message) :
                base(message) {
            }
        }

        #endregion
    }
}
