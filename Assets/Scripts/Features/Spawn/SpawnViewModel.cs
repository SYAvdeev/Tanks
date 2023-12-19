using System;
using Domain.Features;
using Domain.Logic;
using Domain.Logic.GameSpawn;
using Domain.Models;

namespace Features.Spawn
{
    public class SpawnViewModel : BaseViewModel
    {
        private readonly IGameSpawnLogic _gameSpawnLogic;
        
        public event Action<string> SpawnRandomEnemyEvent;
        public event Action<string> SpawnOnShootEvent;

        public SpawnViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            _gameSpawnLogic = logicCollection.Get<IGameSpawnLogic>();
            _gameSpawnLogic.SpawnOnShootEvent += GameSpawnLogicOnSpawnOnShootEvent;
            _gameSpawnLogic.SpawnRandomEnemyEvent += GameSpawnLogicOnSpawnRandomEnemyEvent;
        }

        private void GameSpawnLogicOnSpawnRandomEnemyEvent(string obj)
        {
            SpawnRandomEnemyEvent?.Invoke(obj);
        }

        private void GameSpawnLogicOnSpawnOnShootEvent(string obj)
        {
            SpawnOnShootEvent?.Invoke(obj);
        }
        
        public void InitializeRandomEnemy(IFeatureBase enemyFeatureBase)
        {
            _gameSpawnLogic.InitializeRandomEnemy(enemyFeatureBase);
        }

        public void InitializeBullet(IFeatureBase bulletFeature)
        {
            _gameSpawnLogic.InitializeBullet(bulletFeature);
        }
    }
}