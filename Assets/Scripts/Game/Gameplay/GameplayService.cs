using System.Threading;
using Cysharp.Threading.Tasks;
using Tanks.LevelObjects.Level.Spawn;
using Tanks.Utility;

namespace Tanks.Gameplay
{
    public class GameplayService : IGameplayService
    {
        private readonly ILevelSpawnService _levelSpawnService;
        private readonly ILevelSpawnController _levelSpawnController;
        private readonly UniTaskRestartable _tickTask;

        public GameplayService(ILevelSpawnService levelSpawnService, ILevelSpawnController levelSpawnController)
        {
            _levelSpawnService = levelSpawnService;
            _levelSpawnController = levelSpawnController;
            
            _tickTask = new UniTaskRestartable(Routine);
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _levelSpawnService.Initialize();

            await UniTask.WhenAll(_levelSpawnController.UpdateCurrentLevelControllerTask);
        }

        public void Dispose()
        {
            _tickTask.Cancel();
        }

        private async UniTask Routine(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await UniTask.Yield(cancellationToken);
            }
        }
    }
}