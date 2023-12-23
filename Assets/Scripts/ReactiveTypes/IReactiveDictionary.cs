using System.Collections.Generic;

namespace ReactiveTypes
{
    public interface IReactiveDictionary<TKey, TValue> : IReactiveDictionaryReadOnly<TKey, TValue>
    {
        new TValue this[TKey key] { get; set; }
        void Add(KeyValuePair<TKey, TValue> item);
    }
}