using Configs;
using Domain.Features;

namespace Services.Factory.Features
{
    public interface IFeatureFactory
    {
        public IFeature CreateFeature(FeatureConfig featureConfig);
    }
}