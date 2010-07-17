using System;

namespace IronRuby.Hpricot {
    public interface IHpricotDataContainer {
        T GetData<T>() where T : BasicData;
    }
}
