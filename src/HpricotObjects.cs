using System;

namespace IronRuby.Libraries.Hpricot {

    // TODO: I am starting off with this, it will be refactored later.

    public class HpricotState {
        public Object doc;
        public Object focus;
        public Object last;
        public Object EC;
        public Char xml;
        public Char strict;
        public Char fixup;
    }

    public class HpricotBasic {
        public Object tag;
        public Object parent;
    }

    public class HpricotAttr : HpricotBasic {
        public Object attr;
    }

    public class HpricotElement : HpricotBasic {
        public Object children;
        public Object etag;
        public Object raw;
        public Object EC;
        public Int32 name;
    }
}
