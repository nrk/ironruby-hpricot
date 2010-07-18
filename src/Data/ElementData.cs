using System;
using System.Collections.Generic;
using IronRuby.Builtins;

namespace IronRuby.Hpricot {
    public class ElementData : AttributeData {
        private IList<Object> _children;
        private Object _etag;
        private MutableString _raw;
        private Object _ec;
        private Int32 _name;

        public IList<Object> Children {
            get { return _children; }
            set { _children = value; }
        }

        public Object ETag {
            get { return _etag; }
            set { _etag = value; }
        }

        public MutableString Raw {
            get { return _raw; }
            set { _raw = value; }
        }

        public Object EC {
            get { return _ec; }
            set { _ec = value; }
        }

        public Int32 Name {
            get { return _name; }
            set { _name = value; }
        }
    }
}
