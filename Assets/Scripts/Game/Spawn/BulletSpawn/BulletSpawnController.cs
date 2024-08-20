using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Bullet;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public class BulletSpawnController : IBulletSpawnController
    {
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly BulletSpawnView _bulletSpawnView;

        private readonly IList<IBulletController> _currentSpawnedBulletControllers = new List<IBulletController>();

        private readonly Pool<string, IBulletController> _bulletControllersPool = new ();

        public BulletSpawnController(IBulletSpawnService bulletSpawnService, BulletSpawnView bulletSpawnView)
        {
            _bulletSpawnService = bulletSpawnService;
            _bulletSpawnView = bulletSpawnView;
        }

        public UniTask<IBulletController> SpawnBulletControllerTask { get; private set; }
        
        public void Initialize()
        {
            _bulletSpawnService.Model.BulletSpawned += BulletSpawnModelOnBulletSpawned;
            _bulletSpawnService.Model.BulletAddedToPool += BulletSpawnModelOnBulletAddedToPool;
        }

        private void BulletSpawnModelOnBulletAddedToPool(IBulletService bulletService)
        {
            var bulletController = _currentSpawnedBulletControllers.First(bc => bc.BulletService == bulletService);
            _currentSpawnedBulletControllers.Remove(bulletController);
            _bulletControllersPool.Add(bulletService.BulletModel.Spawnable.Config.ID, bulletController);
        }

        public async UniTask PrewarmBulletControllersPool()
        {
            var bulletSpawnModel = _bulletSpawnService.Model;
            var bulletSpawnConfig = bulletSpawnModel.Config;
            
            foreach (var bulletConfig in bulletSpawnConfig.BulletConfigs)
            {
                for (int i = 0; i < bulletSpawnConfig.PrewarmCount; i++)
                {
                    _bulletSpawnService.SpawnBullet(bulletConfig, Vector2.zero, 0f);
                    await SpawnBulletControllerTask;
                }
            }

            foreach (var bulletService in bulletSpawnModel.CurrentSpawnedBullets)
            {
                bulletSpawnModel.RemoveSpawnedBulletToPool(bulletService);
            }
        }

        private void BulletSpawnModelOnBulletSpawned(IBulletService bulletService)
        {
            SpawnBulletControllerTask = SpawnBulletController(bulletService);
        }
        
        private async UniTask<IBulletController> SpawnBulletController(IBulletService bulletService)
        {
            if (!_bulletControllersPool.TryGet(bulletService.BulletModel.Spawnable.Config.ID, out var bulletController))
            {
                var bulletViewObject = await bulletService.BulletModel.Config.SpawnableConfig.AssetReference.
                    InstantiateAsync(_bulletSpawnView.BulletViewsParent);
                
                var bulletView = bulletViewObject.GetComponent<BulletView>();
                bulletController = new BulletController(bulletView, bulletService);
            }

            _currentSpawnedBulletControllers.Add(bulletController);
            return bulletController;
        }

        public void Dispose()
        {
            _bulletSpawnService.Model.BulletSpawned -= BulletSpawnModelOnBulletSpawned;
            _bulletSpawnService.Model.BulletAddedToPool -= BulletSpawnModelOnBulletAddedToPool;
        }
    }
}