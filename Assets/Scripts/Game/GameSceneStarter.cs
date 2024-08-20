using System.Threading;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Camera;
using Tanks.Game.LevelObjects.Player;
using Tanks.Game.Spawn.BulletSpawn;
using Tanks.Game.Spawn.EnemySpawn;
using Tanks.Game.Spawn.LevelSpawn;
using VContainer.Unity;

namespace Tanks.Game
{
    public class GameSceneStarter : IAsyncStartable
    {
        private readonly ILevelSpawnController _levelSpawnController;
        private readonly ICameraController _cameraController;
        private readonly IPlayerService _playerService;
        private readonly IPlayerController _playerController;
        private readonly IBulletSpawnController _bulletSpawnController;
        private readonly IEnemySpawnController _enemySpawnController;
        private readonly IGameplayService _gameplayService;

        public GameSceneStarter(
            ILevelSpawnController levelSpawnController,
            ICameraController cameraController, 
            IPlayerService playerService, 
            IPlayerController playerController,
            IBulletSpawnController bulletSpawnController,
            IEnemySpawnController enemySpawnController,
            IGameplayService gameplayService)
        {
            _levelSpawnController = levelSpawnController;
            _cameraController = cameraController;
            _playerService = playerService;
            _playerController = playerController;
            _bulletSpawnController = bulletSpawnController;
            _enemySpawnController = enemySpawnController;
            _gameplayService = gameplayService;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _levelSpawnController.Initialize();
            _cameraController.Initialize();
            _playerService.Initialize();
            _playerController.Initialize();
            _bulletSpawnController.Initialize();
            _enemySpawnController.Initialize();

            await _gameplayService.StartGameAsync();
        }
    }
}