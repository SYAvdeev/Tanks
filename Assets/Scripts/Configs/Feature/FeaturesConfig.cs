using UnityEngine;

namespace Configs.Feature
{
    [CreateAssetMenu(fileName ="FeaturesConfig", menuName = "Assets/Config/Features Config", order = 0)]
    public class FeaturesConfig : ScriptableObject
    {
        [SerializeField]
        private FeatureConfigsDictionary _uniqueFeatureConfigs;
        [SerializeField]
        private FeatureConfigsDictionary _spawnableFeatureConfigs;
        [SerializeField]
        private string[] _uniqueFeatureConfigsCreateOrder;
        [SerializeField]
        private string _playerFeatureID;
        [SerializeField]
        private string _levelFeatureID;
        [SerializeField]
        private string _spawnFeatureID;
        [SerializeField]
        private string _cameraFeatureID;

        public FeatureConfigsDictionary UniqueFeatureConfigs => _uniqueFeatureConfigs;
        public FeatureConfigsDictionary SpawnableFeatureConfigs => _spawnableFeatureConfigs;
        public string[] UniqueFeatureConfigsCreateOrder => _uniqueFeatureConfigsCreateOrder;
        public string PlayerFeatureID => _playerFeatureID;
        public string LevelFeatureID => _levelFeatureID;
        public string SpawnFeatureID => _spawnFeatureID;
        public string CameraFeatureID => _cameraFeatureID;
    }
}