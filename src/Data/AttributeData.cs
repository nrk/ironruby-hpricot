using System;
using IronRuby.Builtins;

namespace IronRuby.Hpricot {
    public class AttributeData : BasicData {
        private Object _attr;

        public Object Attr {
            get { return _attr; }
            set { _attr = value; }
        }

        public MutableString AttrAsMutableString {
            get { return (MutableString)_attr; }
        }

        public Hash AttrAsHash {
            get { return (Hash)_attr; }
        }

        public bool AttrIsEmpty {
            get { return _attr == null; }
        }
    }
}
