using System.Collections.Generic;
using Tanks.Game.LevelObjects.Enemy;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnConfig
    {
        int MaxEnemiesCount { get; }
        IReadOnlyCollection<EnemyConfig> EnemyConfigs { get; }
        float EnemySpawnDelay { get; }
    }
}