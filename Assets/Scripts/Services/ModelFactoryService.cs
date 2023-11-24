using System;
using System.Collections.Generic;
using Data.Models;
using Domain.Models;

namespace Services
{
    public class ModelFactoryService : IModelFactoryService
    {
        public IModel CreateModel(IModelData modelData)
        {
            IDictionary<string, IModelProperty> modelProperties = new Dictionary<string, IModelProperty>();

            foreach (KeyValuePair<string, ModelPropertyData> pair in modelData.PropertiesData)
            {
                modelProperties.Add(pair.Key, CreateModelProperty(pair.Value));
            }

            return new Model(modelProperties);
        }
        
        public IModelProperty CreateModelProperty(ModelPropertyData modelPropertyData) =>
            modelPropertyData.ValueTypeNameName switch
            {
                ModelPropertyValueTypeName.Bool => new ModelProperty<bool>(
                    Convert.ToBoolean(modelPropertyData.SerializedValue)),
                ModelPropertyValueTypeName.Int => new ModelProperty<int>(
                    Convert.ToInt32(modelPropertyData.SerializedValue)),
                ModelPropertyValueTypeName.Float => new ModelProperty<float>(
                    Convert.ToSingle(modelPropertyData.SerializedValue)),
                ModelPropertyValueTypeName.String => new ModelProperty<string>(
                    modelPropertyData.SerializedValue),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}