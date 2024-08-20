using System.Threading;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Camera;
using Tanks.Game.LevelObjects.Player;
using Tanks.Game.Spawn.BulletSpawn;
using Tanks.Game.Spawn.EnemySpawn;
using Tanks.Game.Spawn.LevelSpawn;
using Tanks.UI;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game
{
    public class GameplayService : IGameplayService
    {
        private readonly ILevelSpawnService _levelSpawnService;
        private readonly ILevelSpawnController _levelSpawnController;
        private readonly ICameraService _cameraService;
        private readonly IPlayerService _playerService;
        private readonly IPlayerController _playerController;
        private readonly IBulletSpawnService _bulletSpawnService;
        private readonly IBulletSpawnController _bulletSpawnController;
        private readonly IEnemySpawnService _enemySpawnService;
        private readonly IUIService _uiService;
        
        private readonly UniTaskRestartable _updateTask;

        public GameplayService(
            ILevelSpawnService levelSpawnService, 
            ILevelSpawnController levelSpawnController,
            ICameraService cameraService, 
            IPlayerService playerService, 
            IPlayerController playerController,
            IBulletSpawnService bulletSpawnService, 
            IBulletSpawnController bulletSpawnController,
            IEnemySpawnService enemySpawnService,
            IUIService uiService)
        {
            _levelSpawnService = levelSpawnService;
            _levelSpawnController = levelSpawnController;
            _cameraService = cameraService;
            _playerService = playerService;
            _playerController = playerController;
            _bulletSpawnService = bulletSpawnService;
            _bulletSpawnController = bulletSpawnController;
            _enemySpawnService = enemySpawnService;
            _uiService = uiService;
            
            _updateTask = new UniTaskRestartable(UpdateRoutine);
        }

        public async UniTask StartGameAsync()
        {
            _levelSpawnService.SpawnCurrentLevel();
            _cameraService.Update();
            await _playerController.InstantiateWeaponViews();
            _playerService.SetCurrentWeaponOnStart();
            await _bulletSpawnController.PrewarmBulletControllersPool();

            await UniTask.WhenAll(_levelSpawnController.UpdateCurrentLevelControllerTask);
            _updateTask.StartRoutine();
            
            await _uiService.HideScreen<LoadingScreen>(true);
        }

        public void Dispose()
        {
            _updateTask.Cancel();
        }

        private async UniTask UpdateRoutine(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                float deltaTime = Time.deltaTime;
                
                _cameraService.Update();
                _playerService.Update(deltaTime);
                _bulletSpawnService.Update(deltaTime);
                _enemySpawnService.Update(deltaTime);
                
                await UniTask.Yield(cancellationToken);
            }
        }
    }
}