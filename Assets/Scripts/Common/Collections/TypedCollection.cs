using System;
using System.Collections.Generic;

namespace Common.Collections
{
    public class TypedCollection<TBase> : ITypedCollection<TBase>
    {
        private readonly IDictionary<Type, TBase> _dictionary;

        protected TypedCollection()
        {
            _dictionary = new Dictionary<Type, TBase>();
        }
        
        protected TypedCollection(int count)
        {
            _dictionary = new Dictionary<Type, TBase>(count);
        }

        public bool TryGet<T>(out T value) where T : TBase
        {
            Type type = typeof(T);
            if (_dictionary.TryGetValue(type, out TBase valueBase))
            {
                value = (T)valueBase;
                return true;
            }

            foreach (KeyValuePair<Type, TBase> pair in _dictionary)
            {
                if (!type.IsAssignableFrom(pair.Key))
                {
                    continue;
                }
                value = (T)pair.Value;
                return true;
            }

            value = default;
            return false;
        }

        public T Get<T>() where T : TBase
        {
            if (TryGet(out T value))
            {
                return value;
            }

            throw new KeyNotFoundException($"Key {typeof(T)} was not found");
        }

        public void Add<T>(T value) where T : TBase => _dictionary[value.GetType()] = value;
    }
}