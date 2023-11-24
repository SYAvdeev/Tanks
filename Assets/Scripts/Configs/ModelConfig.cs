using System.Collections.Generic;
using Data.Models;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName ="ModelConfig", menuName = "Assets/Config/Model Config", order = 0)]
    public class ModelConfig : ScriptableObject, IModelData
    {
        [SerializeField]
        private ModelPropertyDataDictionary _defaultPropertiesData;

        public IDictionary<string, ModelPropertyData> PropertiesData => _defaultPropertiesData;
    }
}