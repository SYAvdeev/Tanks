using System.Collections.Generic;
using Data.Models;
using Domain.Models;
using UnityEngine;

namespace Configs.Model
{
    [CreateAssetMenu(fileName ="ModelConfig", menuName = "Assets/Config/Model Config", order = 0)]
    public class ModelConfig : ScriptableObject, IModelData
    {
        [SerializeField]
        private ModelPropertyDataDictionary _defaultPropertiesData;
        [SerializeField]
        private ModelListDataDictionary _defaultListsData;

        public IDictionary<ModelPropertyName, ModelPropertyData> PropertiesData => _defaultPropertiesData;
        public IDictionary<ModelListName, ModelListData> ListsData => _defaultListsData;
    }
}