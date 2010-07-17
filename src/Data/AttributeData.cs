using System;
using IronRuby.Builtins;

namespace IronRuby.Hpricot {
    public class AttributeData : BasicData {
        // TODO: Hash or MutableString?
        private Object _attr;

        public Object Attr {
            get { return _attr; }
            set { _attr = value; }
        }

        // TODO: this smells, will fix later
        public bool AttrIsNull {
            get { return _attr == null; }
        }
    }
}
