using System;
using Common;

namespace Domain.Logic.Level
{
    public class SpawnPositionLogic : ISpawnPositionLogic
    {
        private readonly Random _random;
        private readonly RandomUniqueCollection<int> _borderIndices;

        public SpawnPositionLogic(int bordersCount, Random random)
        {
            _random = random;
            _borderIndices = new RandomUniqueCollection<int>(new int[bordersCount], random);
        }

        public int GetBorderIndex() => _borderIndices.Next();
        public float GetPositionNormalized() => (float)_random.NextDouble();
    }
}