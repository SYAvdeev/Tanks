using System.Threading.Tasks;
using Configs.Feature;
using Domain.Features;
using Domain.Logic.Destroyable;
using Features;
using Services.Factory.Features;
using UnityEngine;
using Zenject;

namespace Services
{
    public class SpawnFeatureService : ISpawnFeatureService
    {
        private readonly FeaturesConfig _featuresConfig;
        private readonly IPoolService<IFeature> _featuresPoolService;
        private readonly IFeatureBuilder _featureBuilder;
        private readonly DiContainer _diContainer;

        [Inject]
        public SpawnFeatureService(
            IPoolService<IFeature> featuresPoolService, 
            IFeatureBuilder featureBuilder, 
            FeaturesConfig featuresConfig)
        {
            _featuresPoolService = featuresPoolService;
            _featureBuilder = featureBuilder;
            _featuresConfig = featuresConfig;
        }

        public async Task<IFeature> Create(string id, Transform spawnParent)
        {
            if (!_featuresPoolService.TryGet(id, out IFeature feature))
            {
                FeatureConfig featureConfig = _featuresConfig.SpawnableFeatureConfigs[id];
                feature = await _featureBuilder.Build(featureConfig, spawnParent);
            }
            else
            {
                feature.ViewRoot.transform.parent = spawnParent;
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