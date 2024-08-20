using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Enemy;
using Tanks.Utility;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public class EnemySpawnController : IEnemySpawnController
    {
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly EnemySpawnView _enemySpawnView;

        private readonly IList<IEnemyController> _currentSpawnedEnemyControllers = new List<IEnemyController>();

        private readonly Pool<string, IEnemyController> _enemyControllersPool = new ();

        public EnemySpawnController(IEnemySpawnService enemySpawnService, EnemySpawnView enemySpawnView)
        {
            _enemySpawnService = enemySpawnService;
            _enemySpawnView = enemySpawnView;
        }

        public UniTask<IEnemyController> SpawnEnemyControllerTask { get; private set; }
        
        public void Initialize()
        {
            _enemySpawnService.Model.EnemySpawned += EnemySpawnModelOnEnemySpawned;
            _enemySpawnService.Model.EnemyAddedToPool += EnemySpawnModelOnEnemyAddedToPool;
        }

        private void EnemySpawnModelOnEnemyAddedToPool(IEnemyService enemyService)
        {
            var enemyController = _currentSpawnedEnemyControllers.First(bc => bc.EnemyService == enemyService);
            _currentSpawnedEnemyControllers.Remove(enemyController);
            _enemyControllersPool.Add(enemyService.Model.Spawnable.Config.ID, enemyController);
        }

        private void EnemySpawnModelOnEnemySpawned(IEnemyService enemyService)
        {
            SpawnEnemyControllerTask = SpawnEnemyController(enemyService);
        }
        
        private async UniTask<IEnemyController> SpawnEnemyController(IEnemyService enemyService)
        {
            if (!_enemyControllersPool.TryGet(enemyService.Model.Spawnable.Config.ID, out var enemyController))
            {
                var enemyViewObject = await enemyService.Model.Config.SpawnableConfig.AssetReference.
                    InstantiateAsync(_enemySpawnView.EnemyViewsParent);
                
                var enemyView = enemyViewObject.GetComponent<EnemyView>();
                enemyController = new EnemyController(enemyService, enemyView);
            }

            _currentSpawnedEnemyControllers.Add(enemyController);
            return enemyController;
        }

        public void Dispose()
        {
            foreach (var currentSpawnedEnemyController in _currentSpawnedEnemyControllers)
            {
                currentSpawnedEnemyController.Dispose();
            }
            
            foreach (var (_, value) in _enemyControllersPool.Enumerable)
            {
                foreach (var enemyController in value)
                {
                    enemyController.Dispose();
                }
            }
            
            _enemySpawnService.Model.EnemySpawned -= EnemySpawnModelOnEnemySpawned;
            _enemySpawnService.Model.EnemyAddedToPool -= EnemySpawnModelOnEnemyAddedToPool;
        }
    }
}