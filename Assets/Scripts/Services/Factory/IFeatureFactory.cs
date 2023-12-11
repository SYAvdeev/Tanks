using Configs;
using Domain.Features;
using Domain.Models;
using Features;

namespace Services.Factory
{
    public interface IFeatureFactory
    {
        public IFeature CreateFeature(FeatureConfig featureConfig);
    }

    public class FeatureFactory : IFeatureFactory
    {
        private IModelFactory _modelFactory;
        
        
         
        
        public IFeature CreateFeature(FeatureConfig featureConfig)
        {
            IModel model = _modelFactory.CreateModel(featureConfig.ModelData);
            
            
            Feature feature = new Feature()
        }
    }
}