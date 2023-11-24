using System.Collections.Generic;
using Data.Models;
using Domain.Models;

namespace Data.Service
{
    public class MapModelToDataService : IMapModelToDataService
    {
        private readonly IDataSerializeService _serializeService;

        public MapModelToDataService(IDataSerializeService serializeService)
        {
            _serializeService = serializeService;
        }

        public void Map(IModelData modelData, IModel model)
        {
            foreach (KeyValuePair<string, IModelProperty> pair in model.ModelProperties)
            {
                IModelProperty modelProperty = pair.Value;

                if (!modelData.PropertiesData.ContainsKey(pair.Key))
                {
                    modelData.PropertiesData[pair.Key] = new ModelPropertyData();
                }
                
                ModelPropertyData propertyData = modelData.PropertiesData[pair.Key];
                object modelPropertyValue = modelProperty.Value;
                
                propertyData.ValueTypeNameName = ModelPropertyValueTypeName.Bool.GetValueTypeName(modelPropertyValue);
                propertyData.SerializedValue = _serializeService.Serialize(modelPropertyValue);
            }
        }
    }
}