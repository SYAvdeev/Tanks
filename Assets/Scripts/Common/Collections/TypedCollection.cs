using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            return TryGet(out T value) ? value : default;
        }

        public IEnumerable<T> GetAll<T>() where T : TBase
        {
            Type type = typeof(T);
            return _dictionary.Where(pair => type.IsAssignableFrom(pair.Key)).Select(pair => pair.Value).Cast<T>();
        }

        public void Add<T>(T value) where T : TBase => _dictionary[value.GetType()] = value;
    }
}