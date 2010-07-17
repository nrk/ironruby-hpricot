using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("Doc", DefineIn = typeof(Hpricot))]
    public class Document : IHpricotDataContainer {
        private RubyContext _context;
        private ElementData _data;

        public Document(ScannerState state)
            : this(state.Context) {
        }

        public Document(RubyContext context)
            : this(context, new ElementData()) {
        }

        public Document(RubyContext context, ElementData data) {
            _context = context;
            _data = data;
        }

        public T GetData<T>() where T : BasicData {
            return _data as T;
        }

        [RubyConstructor]
        public static Document Allocator(RubyClass/*!*/ self) {
            return new Document(self.Context);
        }

        [RubyMethod("children")]
        public static Object GetChildren(Document/*!*/ self) {
            return self._data.Children;
        }

        [RubyMethod("children=")]
        public static void SetChildren(Document/*!*/ self, Object/*!*/ children) {
            self._data.Children = children;
        }
    }
}
