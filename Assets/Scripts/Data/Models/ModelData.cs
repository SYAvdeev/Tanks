using System;
using System.Collections.Generic;
using Domain.Models;

namespace Data.Models
{
    [Serializable]
    public class ModelData : IModelData
    {
        public IDictionary<ModelPropertyName, ModelPropertyData> PropertiesData { get; }
        public IDictionary<ModelListName, ModelListData> ListsData { get; }

        public ModelData(IModel model)
        {
            PropertiesData = new Dictionary<ModelPropertyName, ModelPropertyData>(model.Properties.Count);
            ListsData = new Dictionary<ModelListName, ModelListData>(model.Lists.Count);
        }
    }
}