using System;

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
