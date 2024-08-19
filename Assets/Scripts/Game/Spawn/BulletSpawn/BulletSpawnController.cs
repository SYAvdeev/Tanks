using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletSpawnController : IBulletSpawnController
    {
        private readonly IBulletSpawnModel _bulletSpawnModel;
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly BulletSpawnView _bulletSpawnView;
        private readonly IBulletSpawnConfig _bulletSpawnConfig;

        private readonly IList<IBulletController> _currentSpawnedBulletControllers = new List<IBulletController>();

        private readonly Pool<string, IBulletController> _bulletControllersPool = new ();

        public BulletSpawnController(
            IBulletSpawnModel bulletSpawnModel,
            IBulletSpawnService bulletSpawnService,
            BulletSpawnView bulletSpawnView,
            IBulletSpawnConfig bulletSpawnConfig)
        {
            _bulletSpawnModel = bulletSpawnModel;
            _bulletSpawnService = bulletSpawnService;
            _bulletSpawnView = bulletSpawnView;
            _bulletSpawnConfig = bulletSpawnConfig;
        }

        public UniTask<IBulletController> SpawnBulletControllerTask { get; private set; }
        
        public async UniTask Initialize()
        {
            _bulletSpawnModel.BulletSpawned += BulletSpawnModelOnBulletSpawned;
            _bulletSpawnModel.BulletAddedToPool += BulletSpawnModelOnBulletAddedToPool;
            await PrewarmBulletControllersPool();
        }

        private void BulletSpawnModelOnBulletAddedToPool(IBulletService bulletService)
        {
            var bulletController = _currentSpawnedBulletControllers.First(bc => bc.BulletService == bulletService);
            _currentSpawnedBulletControllers.Remove(bulletController);
            _bulletControllersPool.Add(bulletService.BulletModel.Spawnable.Config.ID, bulletController);
        }

        private async UniTask PrewarmBulletControllersPool()
        {
            foreach (var bulletConfig in _bulletSpawnConfig.BulletConfigs)
            {
                _bulletSpawnService.SpawnBullet(bulletConfig, Vector2.zero, 0f);
                await SpawnBulletControllerTask;
            }

            foreach (var bulletService in _bulletSpawnModel.CurrentSpawnedBullets)
            {
                _bulletSpawnModel.RemoveSpawnedBulletToPool(bulletService);
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
            _bulletSpawnModel.BulletSpawned -= BulletSpawnModelOnBulletSpawned;
            _bulletSpawnModel.BulletAddedToPool -= BulletSpawnModelOnBulletAddedToPool;
        }
    }
}