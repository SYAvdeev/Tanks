using System.Collections.Generic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.LevelObjects.Level.Spawn
{
    public class LevelSpawnConfig : ConfigBase, ILevelSpawnConfig
    {
        [SerializeField] private LevelConfig _firstLevelConfig;
        [SerializeField] private List<LevelConfig> _levelConfigs;

        public ILevelConfig FirstLevelConfig => _firstLevelConfig;
        public IReadOnlyCollection<ILevelConfig> LevelConfigs => _levelConfigs;
    }
}