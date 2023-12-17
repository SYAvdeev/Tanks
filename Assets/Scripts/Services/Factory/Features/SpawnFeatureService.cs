using System.Threading.Tasks;
using Configs.Feature;
using Domain.Features;
using Domain.Services;
using Zenject;

namespace Services.Factory.Features
{
    public class SpawnFeatureService : ISpawnFeatureService
    {
        private readonly FeaturesConfig _featuresConfig;
        private readonly IPoolService<IFeature> _featuresPoolService;
        private readonly IFeatureBuilder _featureBuilder;

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

        public async Task<IFeature> Create(string id)
        {
            if (!_featuresPoolService.TryGet(id, out IFeature feature))
            {
                FeatureConfig featureConfig = _featuresConfig.AllFeatureConfigs[id];
                feature = await _featureBuilder.Build(featureConfig);
            }

            return feature;
        }

        public void Delete(IFeature feature)
        {
            _featuresPoolService.Add(feature.ID, feature);
        }
    }
}