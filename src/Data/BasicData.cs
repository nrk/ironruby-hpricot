using System;
using IronRuby.Builtins;

namespace IronRuby.Hpricot {
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
}
