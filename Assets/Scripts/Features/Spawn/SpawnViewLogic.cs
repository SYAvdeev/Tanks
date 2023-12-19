using Cysharp.Threading.Tasks;
using Services;

namespace Features.Spawn
{
    public class SpawnViewLogic : BaseViewLogic<SpawnViewModel, SpawnViewFacade>
    {
        private readonly ISpawnFeatureService _spawnFeatureService;
        
        public SpawnViewLogic(
            SpawnViewModel viewModel, 
            SpawnViewFacade viewFacade,
            ISpawnFeatureService spawnFeatureService) : 
            base(viewModel, viewFacade)
        {
            viewModel.SpawnOnShootEvent += ViewModelOnSpawnOnShootEvent;
            viewModel.SpawnRandomEnemyEvent += ViewModelOnSpawnRandomEnemyEvent;
            _spawnFeatureService = spawnFeatureService;
        }

        private async void ViewModelOnSpawnOnShootEvent(string obj)
        {
            _viewModel.InitializeBullet(await SpawnFeature(obj));
        }

        private async void ViewModelOnSpawnRandomEnemyEvent(string obj)
        {
            _viewModel.InitializeRandomEnemy(await SpawnFeature(obj));
        }

        private async UniTask<IFeature> SpawnFeature(string obj)
        {
            return await _spawnFeatureService.Create(obj, _viewFacade.SpawnParent);
        }
    }
}