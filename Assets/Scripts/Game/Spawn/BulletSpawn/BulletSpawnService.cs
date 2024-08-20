using System.Collections.Generic;
using Tanks.Game.LevelObjects.Bullet;
using Tanks.Game.Spawn.LevelSpawn;
using UnityEngine;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public class BulletSpawnService : IBulletSpawnService
    {
        private readonly ILevelSpawnService _levelSpawnService;
        private readonly object _currentSpawnedBulletsLock = new ();
        public IBulletSpawnModel Model { get; }

        public BulletSpawnService(IBulletSpawnModel model, ILevelSpawnService levelSpawnService)
        {
            Model = model;
            _levelSpawnService = levelSpawnService;
        }

        public void SpawnBullet(IBulletConfig bulletConfig, Vector2 position, float directionAngle)
        {
            if (!Model.BulletsPool.TryGet(bulletConfig.SpawnableConfig.ID, out var bulletService))
            {
                var bulletModel = new BulletModel(bulletConfig);
                bulletService = new BulletService(bulletModel);
                var currentLevelConfig = _levelSpawnService.LevelSpawnModel.CurrentLevelConfig;
                bulletService.MovableService.SetRestrictions(
                    currentLevelConfig.MinPosition,
                    currentLevelConfig.MaxPosition);
                bulletService.MovableService.SetPosition(position);
                bulletService.MovableService.SetDirectionAngle(directionAngle);
                bulletService.Destroyed += BulletServiceOnDestroyed;
            }
            Model.AddSpawnedBullet(bulletService);
        }

        public void Update(float deltaTime)
        {
            lock (_currentSpawnedBulletsLock)
            {
                var spawnedBullets = new List<IBulletService>(Model.CurrentSpawnedBullets);
                foreach (var currentSpawnedBullet in spawnedBullets)
                {
                    currentSpawnedBullet.Update(deltaTime);
                }
            }
        }

        private void BulletServiceOnDestroyed(IBulletService bulletService)
        {
            Model.RemoveSpawnedBulletToPool(bulletService);
        }

        public void Dispose()
        {
            foreach (var currentSpawnedBullet in Model.CurrentSpawnedBullets)
            {
                currentSpawnedBullet.Destroyed -= BulletServiceOnDestroyed;
            }

            foreach (var (_, value) in Model.BulletsPool.Enumerable)
            {
                foreach (var bulletService in value)
                {
                    bulletService.Destroyed -= BulletServiceOnDestroyed;
                }
            }
        }
    }
}