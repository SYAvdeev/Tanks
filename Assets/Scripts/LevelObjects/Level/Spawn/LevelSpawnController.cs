using System.Collections.Generic;
using UnityEngine;

namespace Tanks.LevelObjects.Level.Spawn
{
    public class LevelSpawnController : ILevelSpawnController
    {
        private readonly LevelSpawnView _levelSpawnView;
        private readonly ILevelSpawnService _levelSpawnService;
        private readonly ILevelSpawnModel _levelSpawnModel;

        private readonly Dictionary<string, LevelController> _levelControllersPool = new();

        private LevelController _currentLevelController;

        public LevelSpawnController(LevelSpawnView levelSpawnView,
            ILevelSpawnService levelSpawnService,
            ILevelSpawnModel levelSpawnModel)
        {
            _levelSpawnView = levelSpawnView;
            _levelSpawnService = levelSpawnService;
            _levelSpawnModel = levelSpawnModel;
        }

        public void Initialize()
        {
            _levelSpawnModel.CurrentLevelChanged += LevelSpawnModelOnCurrentLevelChanged;
        }

        private void LevelSpawnModelOnCurrentLevelChanged(ILevelModel levelModel)
        {
            if (_currentLevelController != null)
            {
                string id = _currentLevelController.Model.Spawnable.Config.ID;
                _levelControllersPool.TryAdd(id, _currentLevelController);
                _currentLevelController.View.GameObject.SetActive(false);
            }

            if (!_levelControllersPool.TryGetValue(levelModel.Spawnable.Config.ID, out var levelController))
            {
                var levelView = Object.Instantiate(
                    levelModel.LevelConfig.LevelViewPrefab,
                    _levelSpawnView.LevelViewParent);
                levelController = new LevelController(levelModel, levelView);
            }

            _currentLevelController = levelController;
        }

        public void Dispose()
        {
            _levelSpawnModel.CurrentLevelChanged -= LevelSpawnModelOnCurrentLevelChanged;
        }
    }
}