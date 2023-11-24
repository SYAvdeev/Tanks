using System;

namespace Common
{
    public class RandomUniqueCollection<T>
    {
        private readonly T[] _collection;
        private readonly Random _random;
        
        private int _currentIndex;

        public RandomUniqueCollection(T[] collection, Random random)
        {
            _collection = collection;
            _random = random;
            _currentIndex = 0;
        }

        public T Next()
        {
            T result = _collection[_currentIndex];
            
            ++_currentIndex;
            if (_currentIndex >= _collection.Length)
            {
                _currentIndex = 0;
            }

            return result;
        }

        private void Shuffle()
        {
            for (int i = 0, length = _collection.Length; i < length - 1; ++i)
            {
                int r = _random.Next(0, length);
                (_collection[i], _collection[r]) = (_collection[r], _collection[i]);
            }
        }
    }
}