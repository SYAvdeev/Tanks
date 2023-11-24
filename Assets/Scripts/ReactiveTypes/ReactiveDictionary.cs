using System;
using System.Collections;
using System.Collections.Generic;

namespace ReactiveTypes
{
    public class ReactiveDictionary<TKey, TValue>
          : IDictionary<TKey, TValue>, 
            IReactiveDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _dictionary;
        private readonly Dictionary<TKey, TValue> _lateAdditionalDictionary;
        private readonly List<TKey> _lateRemoveList;

        private readonly GenericPairEventArgs<TKey, TValue> _onAddItemArgs;
        private readonly GenericPairEventArgs<TKey, TValue> _onChangeItemArgs;
        private readonly GenericPairEventArgs<TKey, TValue> _onRemoveArgs;
        private readonly GenericEventArg<IDictionary<TKey, TValue>> _onClearArgs;

        public ReactiveDictionary()
        {
            _dictionary = new Dictionary<TKey, TValue>();
            _lateAdditionalDictionary = new Dictionary<TKey, TValue>();
            _lateRemoveList = new List<TKey>();

            _onAddItemArgs = new GenericPairEventArgs<TKey, TValue>();
            _onClearArgs = new GenericEventArg<IDictionary<TKey, TValue>>();
            _onChangeItemArgs = new GenericPairEventArgs<TKey, TValue>();
            _onRemoveArgs = new GenericPairEventArgs<TKey, TValue>();
        }

        public int Count { get => _dictionary.Count; }

        public bool IsReadOnly { get => false; }

        public TValue this[TKey key]
        {
            get
            {
                try
                {
                    return _dictionary[key];
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        string.Format("Fail get value from {0}. Key: {1}", GetType().Name, key),
                        exception);
                }
            }
            set
            {
                if (_dictionary.ContainsKey(key))
                {
                    TValue currentValue = _dictionary[key];

                    if (!currentValue.Equals(value))
                    {
                        _dictionary[key] = value;
                        FireOnChangeItem(key, value);
                    }
                }
                else
                {
                    _dictionary[key] = value;
                    FireOnAddItem(key, value);
                }
            }
        }

        public ICollection<TKey> Keys { get => _dictionary.Keys; }

        public ICollection<TValue> Values { get => _dictionary.Values; }

        public event Action<GenericPairEventArgs<TKey, TValue>> OnAddItem;
        public event Action<GenericEventArg<IDictionary<TKey, TValue>>> OnClear;
        public event Action<GenericPairEventArgs<TKey, TValue>> OnElementChange;
        public event Action<GenericPairEventArgs<TKey, TValue>> OnRemoveItem;

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dictionary.Add(item.Key, item.Value);
            FireOnAddItem(item.Key, item.Value);
        }

        public void Clear()
        {
            if (OnClear == null)
            {
                _dictionary.Clear();
            }
            else
            {
                Dictionary<TKey, TValue> oldDictionary = new(_dictionary);
                _dictionary.Clear();
                FireOnClear(oldDictionary);
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool containsKey = _dictionary.ContainsKey(item.Key);

            if (containsKey)
            {
                TValue removedValue = _dictionary[item.Key];
                _dictionary.Remove(item.Key);
                FireOnRemoveItem(item.Key, removedValue);
            }

            return containsKey;
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            FireOnAddItem(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            bool containsKey = _dictionary.ContainsKey(key);

            if (containsKey)
            {
                TValue removedValue = _dictionary[key];
                _dictionary.Remove(key);
                FireOnRemoveItem(key, removedValue);
            }

            return containsKey;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            try
            {
                return _dictionary.TryGetValue(key, out value);
            }
            catch (Exception exception)
            {
                string keyInfo = key == null ? "NULL" : key.ToString();

                throw new Exception(
                    string.Format("{0} TryGetValue exception. Key: {1}", GetType().Name, keyInfo),
                    exception);
            }
        }

        /// <summary>
        ///     Если ключ не найден - вернет default вместо выброса исключения
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue GetSafe(TKey key)
        {
            TryGetValue(key, out TValue value);

            return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IDictionary<TKey, TValue> dictionary)
        {
            foreach (KeyValuePair<TKey, TValue> value in dictionary)
            {
                Add(value.Key, value.Value);
            }
        }

        public void AddLate(TKey key, TValue value)
        {
            _lateAdditionalDictionary.Add(key, value);
        }

        public void RemoveLate(TKey key)
        {
            _lateRemoveList.Add(key);
        }

        public void Apply()
        {
            foreach (KeyValuePair<TKey, TValue> value in _lateAdditionalDictionary)
            {
                Add(value);
            }

            foreach (TKey value in _lateRemoveList)
            {
                Remove(value);
            }

            _lateAdditionalDictionary.Clear();
            _lateRemoveList.Clear();
        }

        protected void FireOnChangeItem(TKey key, TValue value)
        {
            _onChangeItemArgs.Key = key;
            _onChangeItemArgs.Value = value;

            OnElementChange?.Invoke(_onChangeItemArgs);
        }

        private void FireOnAddItem(TKey key, TValue value)
        {
            _onAddItemArgs.Key = key;
            _onAddItemArgs.Value = value;

            if (OnAddItem != null)
            {
                OnAddItem(_onAddItemArgs);
            }
        }

        private void FireOnRemoveItem(TKey key, TValue value)
        {
            _onRemoveArgs.Key = key;
            _onRemoveArgs.Value = value;

            if (OnRemoveItem != null)
            {
                OnRemoveItem(_onRemoveArgs);
            }
        }

        private void FireOnClear(IDictionary<TKey, TValue> elements)
        {
            if (OnClear != null)
            {
                _onClearArgs.Value = elements;
                OnClear(_onClearArgs);
            }
        }
    }
}
