using System;
using IronRuby.Builtins;

namespace IronRuby.Hpricot {
    public class BasicData {
        private MutableString _tag;
        private IHpricotDataContainer _parent;

        public MutableString Tag { 
            get { return _tag; } 
            set { _tag = value; }
        }

        public IHpricotDataContainer Parent {
            get { return _parent; }
            set { _parent = value; }
        }
    }
}
