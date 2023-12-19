using System.Collections.Generic;
using Domain.Features;
using Features;

namespace Services.Factory.Features
{
    public class FeaturesPoolService : IPoolService<IFeature>
    {
        private readonly IDictionary<string, Stack<IFeature>> _dictionary;

        public FeaturesPoolService()
        {
            _dictionary = new Dictionary<string, Stack<IFeature>>();
        }

        public bool TryGet(string key, out IFeature feature)
        {
            if (_dictionary.TryGetValue(key, out Stack<IFeature> features) && features.Count > 0)
            {
                feature = features.Pop();
                feature.ViewRoot.gameObject.SetActive(true);
                return true;
            }

            feature = null;
            return false;
        }

        public void Add(string key, IFeature feature)
        {
            if (!_dictionary.TryGetValue(key, out Stack<IFeature> features))
            {
                features = _dictionary[key] = new Stack<IFeature>();
            }
            
            features.Push(feature);
            feature.ViewRoot.gameObject.SetActive(false);
        }
    }
}