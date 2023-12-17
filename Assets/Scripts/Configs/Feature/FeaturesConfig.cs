using UnityEngine;

namespace Configs.Feature
{
    [CreateAssetMenu(fileName ="FeaturesConfig", menuName = "Assets/Config/Features Config", order = 0)]
    public class FeaturesConfig : ScriptableObject
    {
        [SerializeField]
        private FeatureConfigsDictionary _allFeatureConfigs;
        [SerializeField]
        private BindableFeatureConfig[] bindableFeatureConfigs;

        public FeatureConfigsDictionary AllFeatureConfigs => _allFeatureConfigs;
        public BindableFeatureConfig[] BindableFeatureConfigs => bindableFeatureConfigs;
    }
}