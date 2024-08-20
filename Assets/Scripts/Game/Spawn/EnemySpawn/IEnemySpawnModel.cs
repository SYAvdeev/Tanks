using System;
using System.Collections.Generic;
using Tanks.Game.LevelObjects.Enemy;
using Tanks.Utility;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnModel
    {
        IEnemySpawnConfig Config { get; }
        Pool<string, IEnemyService> EnemiesPool { get; }
        IEnumerable<IEnemyService> CurrentSpawnedEnemies { get; }
        event Action<IEnemyService> EnemySpawned;
        event Action<IEnemyService> EnemyRemovedToPool;
        internal void AddSpawnedEnemy(IEnemyService enemyService);
        internal void RemoveSpawnedEnemyToPool(IEnemyService enemyService);
        internal float CurrentSpawnDelay { get; set; }
    }
}