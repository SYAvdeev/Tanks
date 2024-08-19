using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Level;

namespace Tanks.Game.Spawn.LevelSpawn
{
    public class LevelSpawnController : ILevelSpawnController
    {
        private readonly LevelSpawnView _levelSpawnView;
        private readonly ILevelSpawnModel _levelSpawnModel;

        private readonly Dictionary<string, LevelController> _levelControllersPool = new();

        private LevelController _currentLevelController;

        public UniTask<LevelController> UpdateCurrentLevelControllerTask { get; private set; }

        public LevelSpawnController(
            LevelSpawnView levelSpawnView,
            ILevelSpawnModel levelSpawnModel)
        {
            _levelSpawnView = levelSpawnView;
            _levelSpawnModel = levelSpawnModel;
        }

        public void Initialize()
        {
            _levelSpawnModel.CurrentLevelChanged += LevelSpawnModelOnCurrentLevelChanged;
        }

        public void Dispose()
        {
            _levelSpawnModel.CurrentLevelChanged -= LevelSpawnModelOnCurrentLevelChanged;
        }

        private void LevelSpawnModelOnCurrentLevelChanged(ILevelModel levelModel)
        {
            UpdateCurrentLevelControllerTask = UpdateCurrentLevelController(levelModel);
        }

        private async UniTask<LevelController> UpdateCurrentLevelController(ILevelModel levelModel)
        {
            if (_currentLevelController != null)
            {
                string id = _currentLevelController.Model.Spawnable.Config.ID;
                _levelControllersPool.TryAdd(id, _currentLevelController);
                _currentLevelController.View.GameObject.SetActive(false);
            }

            if (!_levelControllersPool.TryGetValue(levelModel.Spawnable.Config.ID, out var levelController))
            {
                var levelViewObject = await levelModel.LevelConfig.SpawnableConfig.AssetReference.
                    InstantiateAsync(_levelSpawnView.LevelViewParent);
                
                var levelView = levelViewObject.GetComponent<LevelView>();
                levelController = new LevelController(levelModel, levelView);
            }

            _currentLevelController = levelController;
            return levelController;
        }
    }
}