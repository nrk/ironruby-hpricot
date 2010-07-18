using System;
using System.Text;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("Comment", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
    public class Comment : BaseElement {
        public Comment(ScannerState state)
            : this(state.Context) {
        }

        public Comment(RubyContext context)
            : base(context) {
        }

        [RubyConstructor]
        public static Comment Allocator(RubyClass/*!*/ self) {
            return new Comment(self.Context);
        }

        protected override MutableString RawString {
            get {
                return MutableString.CreateAscii(String.Format("<!--{0}-->", GetContent(this)));
            }
        }

        [RubyMethod("content")]
        public static MutableString GetContent(Comment/*!*/ self) {
            return self._data.Tag;
        }

        [RubyMethod("content=")]
        public static void SetContent(Comment/*!*/ self, MutableString/*!*/ content) {
            self._data.Tag = content;
        }
    }
}
