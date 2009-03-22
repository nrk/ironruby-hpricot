using System;
using IronRuby.Builtins;

namespace IronRuby.Libraries.Hpricot {

    // TODO: I am starting off with this, it will be refactored later.

    public class BasicData {
        // TODO: MutableString
        public Object tag;
        public Object parent;
    }

    public class AttributeData : BasicData {
        // TODO: Hash or MutableString?
        public Object attr;

        // TODO: this smells, will fix later
        public bool AttrIsNull {
            get { return attr == null; }
        }
    }

    public class ElementData : AttributeData {
        // TODO: RubyArray
        public Object children;
        public Object etag;
        public Object raw;
        public Object EC;
        public Int32 name;
    }
}
