using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("BaseEle", DefineIn=typeof(Hpricot))]
    public abstract class BaseElement : IHpricotDataContainer {
        protected RubyContext _context;
        protected BasicData _data;

        public BaseElement(ScannerState state)
            : this(state.Context, new BasicData()) {
        }

        public BaseElement(ScannerState state, BasicData data)
            : this(state.Context, data) {
        }

        public BaseElement(RubyContext context)
            : this(context, new BasicData()) {
        }

        public BaseElement(RubyContext context, BasicData data) {
            _context = context;
            _data = data;
        }

        public T GetData<T>() where T : BasicData {
            return _data as T;
        }

        protected virtual MutableString RawString {
            get {
                return _data.Tag != null ? _data.Tag as MutableString : MutableString.CreateEmpty();
            }
        }

        [RubyMethod("raw_string")]
        public static MutableString GetRawString(BaseElement/*!*/ self) {
            return self.RawString;
        }

        [RubyMethod("parent")]
        public static Object GetParent(BaseElement/*!*/ self) {
            return self._data.Parent;
        }

        [RubyMethod("parent=")]
        public static void SetParent(BaseElement/*!*/ self, Object/*!*/ parent) {
            self._data.Parent = parent;
        }
    }
}
