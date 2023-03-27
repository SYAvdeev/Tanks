using System;

namespace Domain.LevelObjects.Spawner
{
    public class BordersRandomPosition
    {
        private const int BordersCount = 4;
        public const int PositionsCount = 10;
        private readonly int[] _positions;
        private int _currentIndex = 0;

        public BordersRandomPosition()
        {
            _positions = new int[BordersCount * PositionsCount];
            
            for (int i = 0; i < _positions.Length; i++)
            {
                _positions[i] = i;
            }
            
            int n = _positions.Length;  
            Random random = new Random(DateTime.Now.Millisecond);
            while (n > 1)
            {  
                n--;
                int k = random.Next(n + 1);  
                (_positions[k], _positions[n]) = (_positions[n], _positions[k]);
            } 
        }

        public void GetPosition(out int border, out int position)
        {
            int p = _positions[_currentIndex];
            position = p % PositionsCount;
            border = p / PositionsCount;
            ++_currentIndex;
            if (_currentIndex >= BordersCount * PositionsCount)
            {
                _currentIndex = 0;
            }
        }
    }
}