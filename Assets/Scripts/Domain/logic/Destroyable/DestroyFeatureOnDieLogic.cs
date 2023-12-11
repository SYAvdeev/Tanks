using System;
using Domain.Features;
using Domain.Services;

namespace Domain.Logic.Destroyable
{
    public class DestroyFeatureOnDieLogic : IDestroyableFeatureLogic
    {
        private readonly IFeature _feature;
        private readonly ISpawnFeatureService _spawnFeatureService;

        public event Action<IFeature> Destroyed;

        public DestroyFeatureOnDieLogic(IFeature feature, ISpawnFeatureService spawnFeatureService)
        {
            _feature = feature;
            _spawnFeatureService = spawnFeatureService;
        }

        public void Destroy()
        {
            _spawnFeatureService.Delete(_feature);
            Destroyed?.Invoke(_feature);
        }
    }
}