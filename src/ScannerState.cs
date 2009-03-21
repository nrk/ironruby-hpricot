using System;

namespace IronRuby.Libraries.Hpricot {

    // TODO: I am starting off with this, it will be refactored later.

    public class ScannerState {
        public Object doc;
        public Object focus;
        public Object last;
        public Object EC;
        public Char xml;
        public Char strict;
        public Char fixup;
    }
}
