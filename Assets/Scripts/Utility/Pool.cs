using System.Collections.Generic;

namespace Tanks.Utility
{
    public class Pool<TKey, TValue>
    {
        private readonly Dictionary<TKey, Stack<TValue>> _dictionary = new();

        public bool TryGet(TKey key, out TValue value)
        {
            if (!_dictionary.TryGetValue(key, out Stack<TValue> stack))
            {
                _dictionary[key] = new Stack<TValue>();
            }

            if (_dictionary[key].TryPop(out value))
            {
                return true;
            }

            value = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue value)
        {
            if (!_dictionary.TryGetValue(key, out Stack<TValue> stack))
            {
                _dictionary[key] = new Stack<TValue>();
            }
            
            _dictionary[key].Push(value);
        }
    }
}