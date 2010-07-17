using System;
using System.Collections.Generic;

namespace IronRuby.FastXs {
    /// <summary>
    /// 
    /// </summary>
    public interface EntityMap {
        /// <summary>
        /// Add an entry to this entity map.
        /// </summary>
        /// <param name="name">the entity name</param>
        /// <param name="value">the entity value</param>
        void Add(String name, Int32 value);

        /// <summary>
        /// Returns the name of the entity identified by the specified value.
        /// </summary>
        /// <param name="value">the value to locate</param>
        /// <returns>entity name associated with the specified value</returns>
        String Name(Int32 value);

        /// <summary>
        /// Returns the value of the entity identified by the specified name.
        /// </summary>
        /// <param name="name">the name to locate</param>
        /// <returns>entity value associated with the specified name</returns>
        int Value(String name);
    }

    /// <summary>
    /// 
    /// </summary>
    public class PrimitiveEntityMap : EntityMap {
        private Dictionary<String, Int32>/*!*/ _mapNameToValue;
        private Dictionary<Int32, String>/*!*/ _mapValueToName;

        public PrimitiveEntityMap() {
            _mapNameToValue = new Dictionary<String, Int32>();
            _mapValueToName = new Dictionary<Int32, String>();
        }

        public void Add(String/*!*/ name, Int32 value) {
            _mapNameToValue.Add(name, value);
            _mapValueToName.Add(value, name);
        }

        public String Name(Int32 value) {
            return _mapValueToName.ContainsKey(value) ? _mapValueToName[value] : null;
        }

        public int Value(String/*!*/ name) {
            return _mapNameToValue.ContainsKey(name) ? _mapNameToValue[name] : -1;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class LookupEntityMap : PrimitiveEntityMap {
        private String[] _lookupTable;
        private const int LOOKUP_TABLE_SIZE = 256;

        public new String Name(int value) {
            if (value < LOOKUP_TABLE_SIZE) {
                return LookupTable[value];
            }
            return base.Name(value);
        }

        private String[] LookupTable {
            get {
                if (_lookupTable == null) {
                    CreateLookupTable();
                }
                return _lookupTable;
            }
        }

        private void CreateLookupTable() {
            _lookupTable = new String[LOOKUP_TABLE_SIZE];
            for (int i = 0; i < LOOKUP_TABLE_SIZE; ++i) {
                _lookupTable[i] = base.Name(i);
            }
        }
    }
}
