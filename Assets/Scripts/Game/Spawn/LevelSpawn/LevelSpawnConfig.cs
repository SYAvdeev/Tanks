using System.Collections.Generic;
using Tanks.Game.LevelObjects.Level;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.Spawn.LevelSpawn
{
    [CreateAssetMenu(
        fileName = nameof(LevelSpawnConfig), 
        menuName = "Custom/Game/Spawn/" + nameof(LevelSpawnConfig),
        order = 0)]
    public class LevelSpawnConfig : ConfigBase, ILevelSpawnConfig
    {
        [SerializeField] private LevelConfig _firstLevelConfig;
        [SerializeField] private List<LevelConfig> _levelConfigs;

        public ILevelConfig FirstLevelConfig => _firstLevelConfig;
        public IReadOnlyCollection<ILevelConfig> LevelConfigs => _levelConfigs;
    }
}