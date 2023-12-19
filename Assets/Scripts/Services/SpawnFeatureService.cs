using System.Threading.Tasks;
using Configs.Feature;
using Domain.Features;
using Domain.Logic.Destroyable;
using Features;
using Services.Factory.Features;
using Services.PrototypeProvider;
using UnityEngine;
using Zenject;

namespace Services
{
    public class SpawnFeatureService : ISpawnFeatureService
    {
        private readonly FeaturesConfig _featuresConfig;
        private readonly IPoolService<IFeature> _featuresPoolService;
        private readonly IFeatureBuilder _featureBuilder;
        private readonly IAssetsSpawnService _assetsSpawnService;
        private readonly DiContainer _diContainer;

        [Inject]
        public SpawnFeatureService(
            IPoolService<IFeature> featuresPoolService, 
            IFeatureBuilder featureBuilder, 
            FeaturesConfig featuresConfig,
            IAssetsSpawnService assetsSpawnService)
        {
            _featuresPoolService = featuresPoolService;
            _featureBuilder = featureBuilder;
            _featuresConfig = featuresConfig;
            _assetsSpawnService = assetsSpawnService;
        }

        public async Task<IFeature> Create(string id, Transform viewParent)
        {
            if (!_featuresPoolService.TryGet(id, out IFeature feature))
            {
                FeatureConfig featureConfig = _featuresConfig.SpawnableFeatureConfigs[id];
                feature = await _featureBuilder.Build(featureConfig, viewParent);
            }
            else
            {
                feature.ViewRoot.transform.parent = viewParent;
            }

            if (feature.LogicCollection.TryGet(out IDestroyableFeatureLogic destroyableFeatureLogic))
            {
                destroyableFeatureLogic.Destroyed += DestroyableFeatureLogicOnDestroyed;
            }

            return feature;
        }

        private void DestroyableFeatureLogicOnDestroyed(IFeatureBase featureBase)
        {
            Delete((IFeature)featureBase);
        }

        public void Delete(IFeature feature)
        {
            if (feature.LogicCollection.TryGet(out IDestroyableFeatureLogic destroyableFeatureLogic))
            {
                destroyableFeatureLogic.Destroyed -= DestroyableFeatureLogicOnDestroyed;
            }
            
            _featuresPoolService.Add(feature.ID, feature);
        }
    }
}