using System;
using IronRuby.Builtins;

namespace IronRuby.Hpricot {
    public class ScannerState {
        #region fields

        private IHpricotDataContainer _doc;
        private IHpricotDataContainer _focus;
        private IHpricotDataContainer _last;
        private Hash _ec;
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

        public IHpricotDataContainer Doc {
            get { return _doc; }
            set { _doc = value; }
        }

        public IHpricotDataContainer Focus {
            get { return _focus; }
            set { _focus = value; }
        }

        public IHpricotDataContainer Last {
            get { return _last; }
            set { _last = value; }
        }

        public Hash EC {
            get { return _ec; }
            set { _ec = value; }
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
