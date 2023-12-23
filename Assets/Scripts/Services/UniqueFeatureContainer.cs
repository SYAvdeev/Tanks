using System.Collections.Generic;
using Domain.Features;
using Domain.Services;
using Features;

namespace Services
{
    public class UniqueFeatureContainer : IUniqueFeaturesContainer
    {
        private readonly IDictionary<string, IFeature> _features;

        public UniqueFeatureContainer()
        {
            _features = new Dictionary<string, IFeature>();
        }

        public IFeature GetFeature(string featureID) => _features[featureID];

        public void Add(IFeature featureBase) => _features[featureBase.ID] = featureBase;
    }
}