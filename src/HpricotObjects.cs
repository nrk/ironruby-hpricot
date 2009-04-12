using System;
using IronRuby.Builtins;

namespace IronRuby.Libraries.Hpricot {
    #region BasicData 

    public class BasicData {
        private Object _tag;
        private Object _parent;

        public Object Tag { 
            get { return _tag; } 
            set { _tag = value; }
        }

        public Object Parent {
            get { return _parent; }
            set { _parent = value; }
        }
    }

    #endregion

    #region AttributeData

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

    #endregion

    #region ElementData

    public class ElementData : AttributeData {
        // TODO: RubyArray
        private Object _children;
        private Object _etag;
        private Object _raw;
        private Object _ec;
        private Int32 _name;

        public Object Children {
            get { return _children; }
            set { _children = value; }
        }

        public Object ETag {
            get { return _etag; }
            set { _etag = value; }
        }

        public Object Raw {
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

    #endregion
}
