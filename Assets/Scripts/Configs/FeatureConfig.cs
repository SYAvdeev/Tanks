using Configs.Model;
using Data.Models;
using Services.Factory.Logic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName ="FeatureConfig", menuName = "Assets/Config/Feature Config", order = 0)]
    public class FeatureConfig : ScriptableObject, IFeatureData
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private ModelConfig _modelConfig;
        [SerializeField]
        private LogicFactoryType[] _logicTypes;
        [SerializeField]
        private string _featureRootAssetKey;

        public string ID => _id;
        public IModelData ModelData => _modelConfig;
        public LogicFactoryType[] LogicTypes => _logicTypes;
        public string FeatureRootAssetKey => _featureRootAssetKey;
    }
}