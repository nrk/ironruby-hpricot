using System;
using System.Text;
using System.Collections.Generic;
using IronRuby.Builtins;
using IronRuby.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace IronRuby.Hpricot {
    [RubyClass("Elem", Inherits = typeof(BaseElement), DefineIn = typeof(Hpricot))]
    public class Element : BaseElement {
        public Element(ScannerState state)
            : this(state.Context) {
        }

        public Element(RubyContext context)
            : base(context, new ElementData()) {
        }

        [RubyConstructor]
        public static Element Allocator(RubyClass/*!*/ self) {
            return new Element(self.Context);
        }

        [RubyMethod("raw_string")]
        public static Object GetRawString(Element/*!*/ self) {
            return (self._data as ElementData).Raw;
        }

        [RubyMethod("clear_raw")]
        public static bool ClearRaw(Element/*!*/ self) {
            (self._data as ElementData).Raw = null;
            return true;
        }

        [RubyMethod("raw_attributes")]
        public static Object GetRawAttributes(Element/*!*/ self) {
            return (self._data as ElementData).Attr;
        }

        [RubyMethod("raw_attributes=")]
        public static void SetRawAttributes(Element/*!*/ self, Object/*!*/ rawAttributes) {
            (self._data as ElementData).Attr = rawAttributes;
        }

        [RubyMethod("children")]
        public static IList<Object> GetChildren(Element/*!*/ self) {
            return (self._data as ElementData).Children;
        }

        [RubyMethod("children=")]
        public static void SetChildren(Element/*!*/ self, IList<Object>/*!*/ children) {
            (self._data as ElementData).Children = children;
        }

        [RubyMethod("etag")]
        public static Object GetEtag(Element/*!*/ self) {
            return (self._data as ElementData).ETag;
        }

        [RubyMethod("etag=")]
        public static void SetEtag(Element/*!*/ self, Object/*!*/ etag) {
            (self._data as ElementData).ETag = etag;
        }

        [RubyMethod("name")]
        public static Object GetName(Element/*!*/ self) {
            return self._data.Tag;
        }

        [RubyMethod("name=")]
        public static void SetName(Element/*!*/ self, Object/*!*/ name) {
            self._data.Tag = name;
        }
    }
}
