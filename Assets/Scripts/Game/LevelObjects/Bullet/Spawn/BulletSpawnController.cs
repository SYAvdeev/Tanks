using Cysharp.Threading.Tasks;
using Tanks.Utility;

namespace Tanks.Bullet
{
    public class BulletSpawnController : IBulletSpawnController
    {
        private readonly IBulletSpawnModel _bulletSpawnModel;
        private readonly BulletSpawnView _bulletSpawnView;

        private readonly Pool<string, IBulletController> _bulletsPool = new ();

        public BulletSpawnController(IBulletSpawnModel bulletSpawnModel, BulletSpawnView bulletSpawnView)
        {
            _bulletSpawnModel = bulletSpawnModel;
            _bulletSpawnView = bulletSpawnView;
        }

        public UniTask<IBulletController> SpawnBulletControllerTask { get; private set; }
        
        public void Initialize()
        {
            _bulletSpawnModel.BulletSpawned += BulletSpawnModelOnBulletSpawned;
        }

        private void BulletSpawnModelOnBulletSpawned(IBulletService bulletService)
        {
            SpawnBulletControllerTask = SpawnBulletController(bulletService);
        }
        
        private async UniTask<IBulletController> SpawnBulletController(IBulletService bulletService)
        {
            if (!_bulletsPool.TryGet(bulletService.BulletModel.Spawnable.Config.ID, out var bulletController))
            {
                var bulletViewObject = await bulletService.BulletModel.Config.SpawnableConfig.AssetReference.
                    InstantiateAsync(_bulletSpawnView.BulletViewsParent);
                
                var bulletView = bulletViewObject.GetComponent<BulletView>();
                bulletController = new BulletController(bulletView, bulletService);
            }

            return bulletController;
        }

        public void Dispose()
        {
            _bulletSpawnModel.BulletSpawned += BulletSpawnModelOnBulletSpawned;
        }
    }
}