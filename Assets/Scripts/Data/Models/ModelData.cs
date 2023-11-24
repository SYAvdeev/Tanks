using System;
using System.Collections.Generic;
using Domain.Models;

namespace Data.Models
{
    [Serializable]
    public class ModelData : IModelData
    {
        //private readonly IModel _model;
        public IDictionary<string, ModelPropertyData> PropertiesData { get; }

        public ModelData(IModel model)
        {
            //_model = model;
            PropertiesData = new Dictionary<string, ModelPropertyData>(model.ModelProperties.Count);
        }
    }
}