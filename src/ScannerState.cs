using System;
using IronRuby.Builtins;

namespace IronRuby.Libraries.Hpricot {
    public class ScannerState {
        #region fields

        private Object _doc;
        private Object _focus;
        private Object _last;
        private Object _EC;
        private bool _xml;
        private bool _strict;
        private bool _fixup;

        #endregion

        #region constructors

        public ScannerState() {
            _xml = false;
            _strict = false;
            _fixup = false;
        }

        #endregion

        #region properties 

        public Object Doc {
            get { return _doc; }
            set { _doc = value; }
        }

        public Object Focus {
            get { return _focus; }
            set { _focus = value; }
        }

        public Object Last {
            get { return _last; }
            set { _last = value; }
        }

        public Object EC {
            get { return _EC; }
            set { _EC = value; }
        }

        public bool Xml {
            get { return _xml; }
            set { _xml = value; }
        }

        public bool Strict {
            get { return _strict; }

            //TODO: setting Strict to true should set Fixup to true automatically.
            set { _strict = value; }
        }
        
        public bool Fixup {
            get { return _fixup; }
            set { _fixup = value; }
        }

        #endregion
    }
}
