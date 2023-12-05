using Configs.ViewModel;
using Data.Models;
using UnityEngine;

namespace Configs.Model
{
    [CreateAssetMenu(fileName ="ModelConfig", menuName = "Assets/Config/Model Config", order = 0)]
    public class FeatureConfig : ScriptableObject, IFeatureData
    {
        [SerializeField]
        private string Name;
        [SerializeField]
        private ModelConfig _modelConfig;
        [SerializeField]
        private ViewModelConfig[] _viewModelConfigs;

        public string ID => Name;
        public IModelData ModelData => _modelConfig;
    }
}