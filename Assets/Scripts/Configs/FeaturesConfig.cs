using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName ="FeaturesConfig", menuName = "Assets/Config/Features Config", order = 0)]
    public class FeaturesConfig : ScriptableObject
    {
        [SerializeField]
        private FeatureConfigsDictionary _featureConfigsDictionary;

        public FeatureConfigsDictionary FeatureConfigsDictionary => _featureConfigsDictionary;
    }
}