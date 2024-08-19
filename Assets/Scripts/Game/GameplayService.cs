using System.Threading;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Level;
using Tanks.UI;
using Tanks.Utility;

namespace Tanks.Game
{
    public class GameplayService : IGameplayService
    {
        private readonly ILevelSpawnService _levelSpawnService;
        private readonly ILevelSpawnController _levelSpawnController;
        private readonly IUIService _uiService;
        private readonly UniTaskRestartable _updateTask;
        
        
        public GameplayService(
            ILevelSpawnService levelSpawnService,
            ILevelSpawnController levelSpawnController, 
            IUIService uiService)
        {
            _levelSpawnService = levelSpawnService;
            _levelSpawnController = levelSpawnController;
            _uiService = uiService;
            
            _updateTask = new UniTaskRestartable(UpdateRoutine);
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _levelSpawnController.Initialize();
            _levelSpawnService.Initialize();

            await UniTask.WhenAll(_levelSpawnController.UpdateCurrentLevelControllerTask);
            
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
                await UniTask.Yield(cancellationToken);
            }
        }
    }
}