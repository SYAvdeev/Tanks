using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReactiveTypes
{
    public class ReactiveList<T> : IList<T>, IReactiveList<T>
    {
        private readonly List<T> _list;
        
        private readonly GenericEventArg<IEnumerable<T>> _onClearArgs;
        private readonly GenericPairEventArgs<int, T> _onAddItemArgs;
        private readonly GenericPairEventArgs<int, T> _onElementChangeArgs;
        private readonly GenericPairEventArgs<int, T> _onRemoveArgs;
        private readonly ReactiveListSortingArgs<T> _onSortingArgs;

        public ReactiveList(IReadOnlyList<T> collection)
            : this(collection.Count)
        {
            AddRange(collection);
        }
        
        public ReactiveList()
            : this(0)
        { }

        public ReactiveList(int count)
        {
            _list = new List<T>(count);

            _onClearArgs = new GenericEventArg<IEnumerable<T>>();
            _onAddItemArgs = new GenericPairEventArgs<int, T>();
            _onElementChangeArgs = new GenericPairEventArgs<int, T>();
            _onRemoveArgs = new GenericPairEventArgs<int, T>();
            _onSortingArgs = new ReactiveListSortingArgs<T>();
        }

        public int Count { get => _list.Count; }

        public bool IsReadOnly { get => false; }

        public T this[int index]
        {
            get => _list[index];
            set
            {
                _list[index] = value;
                FireOnElementChange(value, index);
            }
        }

        public event Action<GenericPairEventArgs<int, T>> OnAddItem;
        public event Action<GenericEventArg<IEnumerable<T>>> OnClear;
        public event Action<GenericPairEventArgs<int, T>> OnElementChange;
        public event Action<GenericPairEventArgs<int, T>> OnRemoveItem;
        public event Action<ReactiveListSortingArgs<T>> OnSort;

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);
            FireOnAddItem(item, _list.Count - 1);
        }

        public void Clear()
        {
            if (OnClear != null)
            {
                List<T> clearedElements = new(_list.Count);
                clearedElements.AddRange(_list);
                _list.Clear();
                FireOnClear(clearedElements);
            }
            else
            {
                _list.Clear();
            }
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            bool containsItem = _list.Contains(item);

            if (containsItem)
            {
                int index = _list.IndexOf(item);
                _list.Remove(item);
                FireOnRemoveItem(item, index);
            }

            return containsItem;
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            FireOnAddItem(item, index);
        }

        public void RemoveAt(int index)
        {
            T removedItem = _list[index];
            _list.RemoveAt(index);
            FireOnRemoveItem(removedItem, index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IReadOnlyList<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public void AddRange(ReactiveList<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        public void RemoveRange(int index, int count)
        {
            List<T> removed = null;

            if (OnRemoveItem != null)
            {
                removed = _list.GetRange(index, count);
            }
            
            _list.RemoveRange(index, count);

            if (OnRemoveItem != null)
            {
                for (int i = 0; i < removed.Count; i++)
                {
                    FireOnRemoveItem(removed[i], index + i);
                }
            }
        }

        public void Sort()
        {
            List<T> tmpList = _list.ToList();
            _list.Sort();
            FireOnSort(tmpList);
        }

        public void Sort(IComparer<T> comparer)
        {
            List<T> tmpList = _list.ToList();
            _list.Sort(comparer);
            FireOnSort(tmpList);
        }

        public void Sort(Comparison<T> comparer)
        {
            List<T> tmpList = _list.ToList();
            _list.Sort(comparer);
            FireOnSort(tmpList);
        }

        private void FireOnAddItem(T item, int index)
        {
            if (OnAddItem != null)
            {
                _onAddItemArgs.Key = index;
                _onAddItemArgs.Value = item;
                OnAddItem(_onAddItemArgs);
            }
        }

        private void FireOnRemoveItem(T item, int index)
        {
            if (OnRemoveItem != null)
            {
                _onRemoveArgs.Key = index;
                _onRemoveArgs.Value = item;
                OnRemoveItem(_onRemoveArgs);
            }
        }

        private void FireOnElementChange(T item, int index)
        {
            if (OnElementChange != null)
            {
                _onElementChangeArgs.Key = index;
                _onElementChangeArgs.Value = item;
                OnElementChange(_onElementChangeArgs);
            }
        }

        private void FireOnClear(IEnumerable<T> items)
        {
            if (OnClear != null)
            {
                _onClearArgs.Value = items;
                OnClear(_onClearArgs);
            }
        }

        private void FireOnSort(List<T> beforeSortList)
        {
            if (OnSort == null)
            {
                return;
            }

            for (int oldIndex = 0; oldIndex < beforeSortList.Count; oldIndex++)
            {
                T oldValue = beforeSortList[oldIndex];
                int newIndex = _list.IndexOf(oldValue);

                if (newIndex != oldIndex)
                {
                    _onSortingArgs.OldIndex = oldIndex;
                    _onSortingArgs.NewIndex = newIndex;
                    _onSortingArgs.Value = oldValue;
                    OnSort(_onSortingArgs);
                }
            }
        }
    }
}
