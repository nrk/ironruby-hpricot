using System;
using System.Text;
using System.Diagnostics;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("ETag", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
    public class ETag : BaseElement {
        public ETag(ScannerState state)
            : this(state.Context) {
        }

        public ETag(RubyContext context)
            : base(context, new AttributeData()) {
        }

        [RubyConstructor]
        public static ETag Allocator(RubyClass/*!*/ self) {
            return new ETag(self.Context);
        }

        [RubyMethod("raw_string")]
        public static MutableString GetRawString(ETag/*!*/ self) {
            return self.GetData<AttributeData>().AttrAsMutableString;
        }

        [RubyMethod("clear_raw")]
        public static bool ClearRaw(ETag/*!*/ self) {
            self.GetData<AttributeData>().Attr = null;
            return true;
        }

        [RubyMethod("name")]
        public static MutableString GetName(ETag/*!*/ self) {
            return self._data.Tag;
        }

        [RubyMethod("name=")]
        public static void SetName(ETag/*!*/ self, MutableString/*!*/ name) {
            self._data.Tag = name;
        }
    }
}
