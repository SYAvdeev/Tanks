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

        public bool TryGet<T>(out T value) where T : TBase
        {
            if (_dictionary.TryGetValue(typeof(T), out TBase valueBase))
            {
                value = (T)valueBase;
                return true;
            }

            value = default;
            return false;
        }

        public T Get<T>() where T : TBase => (T)_dictionary[typeof(T)];

        public void Add<T>(T value) where T : TBase => _dictionary[typeof(T)] = value;
    }
}