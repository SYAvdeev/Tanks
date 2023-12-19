using System.Collections.Generic;
using Domain.Features;
using Domain.Services;

namespace Services
{
    public class UniqueFeatureContainer : IUniqueFeaturesContainer
    {
        private readonly IDictionary<string, IFeatureBase> _features;

        public UniqueFeatureContainer()
        {
            _features = new Dictionary<string, IFeatureBase>();
        }

        public IFeatureBase GetFeature(string featureID) => _features[featureID];

        public void Add(IFeatureBase featureBase) => _features[featureBase.ID] = featureBase;
    }
}