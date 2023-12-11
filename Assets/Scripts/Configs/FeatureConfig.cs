using Configs.Model;
using Configs.ViewModel;
using Data.Models;
using Services.Factory;
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
        private ViewModelConfig[] _viewModelConfigs;

        public string ID => _id;
        public IModelData ModelData => _modelConfig;
    }
}