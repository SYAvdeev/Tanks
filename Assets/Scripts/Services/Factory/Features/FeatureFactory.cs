using Configs;
using Domain.Features;
using Domain.Models;
using Domain.Services;
using Features;

namespace Services.Factory.Features
{
    public class FeatureFactory : IFeatureFactory
    {
        private IModelFactory _modelFactory;
        private ILogicFactory _logicFactory;
        private ISpawnFeatureService _spawnFeatureService;

        public IFeature CreateFeature(FeatureConfig featureConfig)
        {
            IModel model = _modelFactory.CreateModel(featureConfig.ModelData);
            
            //IFeature feature = new Feature(featureConfig.ID, )

            _spawnFeatureService.Create(featureConfig.FeatureRootAssetKey);

            for (int i = 0; i < featureConfig.LogicTypes.Length; i++)
            {
                _logicFactory.CreateLogic()
            }
        }
    }
}