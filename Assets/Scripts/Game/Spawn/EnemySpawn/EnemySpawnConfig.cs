using System.Collections.Generic;
using Tanks.Game.LevelObjects.Enemy;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.Spawn.EnemySpawn
{
    [CreateAssetMenu(
        fileName = nameof(EnemySpawnConfig),
        menuName = "Custom/Game/LevelObjects/Spawn/" + nameof(EnemySpawnConfig),
        order = 1)]
    public class EnemySpawnConfig : ConfigBase, IEnemySpawnConfig
    {
        [SerializeField] private int _maxEnemiesCount;
        [SerializeField] private List<EnemyConfig> _enemyConfigs;
        [SerializeField] private float _enemySpawnDelay;

        public int MaxEnemiesCount => _maxEnemiesCount;
        public IReadOnlyCollection<EnemyConfig> EnemyConfigs => _enemyConfigs;
        public float EnemySpawnDelay => _enemySpawnDelay;
    }
}