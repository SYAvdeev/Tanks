using System.Collections.Generic;

namespace Common.Collections
{
    public interface ITypedCollection<in TBase>
    {
        bool TryGet<T>(out T logic) where T : TBase;
        T Get<T>() where T : TBase;
        IEnumerable<T> GetAll<T>() where T : TBase;
        void Add<T>(T value) where T : TBase;
    }
}