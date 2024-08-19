using System;
using System.Collections.Generic;
using Tanks.Game.LevelObjects.Enemy;
using Tanks.Utility;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public class EnemySpawnModel : IEnemySpawnModel
    {
        private readonly List<IEnemyService> _currentSpawnedEnemies = new();
        public IEnemySpawnConfig Config { get; }
        public Pool<string, IEnemyService> EnemiesPool { get; } = new();

        public EnemySpawnModel(IEnemySpawnConfig config)
        {
            ((IEnemySpawnModel)this).CurrentSpawnDelay = config.EnemySpawnDelay;
            Config = config;
        }

        public IEnumerable<IEnemyService> CurrentSpawnedEnemies => _currentSpawnedEnemies;
        public event Action<IEnemyService> EnemySpawned;
        public event Action<IEnemyService> EnemyAddedToPool;


        void IEnemySpawnModel.AddSpawnedEnemy(IEnemyService enemyService)
        {
            _currentSpawnedEnemies.Add(enemyService);
        }

        void IEnemySpawnModel.RemoveSpawnedEnemyToPool(IEnemyService enemyService)
        {
            _currentSpawnedEnemies.Remove(enemyService);
            EnemiesPool.Add(enemyService.Model.Config.SpawnableConfig.ID, enemyService);
        }

        float IEnemySpawnModel.CurrentSpawnDelay { get; set; }
    }
}