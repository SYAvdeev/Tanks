using Tanks.Game.LevelObjects.Level;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletSpawnService : IBulletSpawnService
    {
        private readonly IBulletSpawnModel _bulletSpawnModel;
        private readonly ILevelSpawnService _levelSpawnService;

        public BulletSpawnService(IBulletSpawnModel bulletSpawnModel, ILevelSpawnService levelSpawnService)
        {
            _bulletSpawnModel = bulletSpawnModel;
            _levelSpawnService = levelSpawnService;
        }

        public void SpawnBullet(IBulletConfig bulletConfig, Vector2 position, float rotation)
        {
            if (!_bulletSpawnModel.BulletsPool.TryGet(bulletConfig.SpawnableConfig.ID, out var bulletService))
            {
                var bulletModel = new BulletModel(bulletConfig);
                bulletService = new BulletService(bulletModel);
                var currentLevelConfig = _levelSpawnService.LevelSpawnModel.CurrentLevelConfig;
                bulletService.MovableService.SetRestrictions(
                    currentLevelConfig.MinPosition,
                    currentLevelConfig.MaxPosition);
                bulletService.Destroyed += BulletServiceOnDestroyed;
            }
            _bulletSpawnModel.AddSpawnedBullet(bulletService);
        }

        private void BulletServiceOnDestroyed(IBulletService bulletService)
        {
            _bulletSpawnModel.RemoveSpawnedBulletToPool(bulletService);
        }

        public void Dispose()
        {
            foreach (var currentSpawnedBullet in _bulletSpawnModel.CurrentSpawnedBullets)
            {
                currentSpawnedBullet.Destroyed -= BulletServiceOnDestroyed;
            }

            foreach (var (_, value) in _bulletSpawnModel.BulletsPool.Enumerable)
            {
                foreach (var bulletService in value)
                {
                    bulletService.Destroyed -= BulletServiceOnDestroyed;
                }
            }
        }
    }
}