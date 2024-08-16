using System.Collections.Generic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Level
{
    [CreateAssetMenu(
        fileName = nameof(LevelSpawnConfig), 
        menuName = "Custom/LevelObjects/Spawn/" + nameof(LevelSpawnConfig),
        order = 0)]
    public class LevelSpawnConfig : ConfigBase, ILevelSpawnConfig
    {
        [SerializeField] private LevelConfig _firstLevelConfig;
        [SerializeField] private List<LevelConfig> _levelConfigs;

        public ILevelConfig FirstLevelConfig => _firstLevelConfig;
        public IReadOnlyCollection<ILevelConfig> LevelConfigs => _levelConfigs;
    }
}