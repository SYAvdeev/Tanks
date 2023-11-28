using System.Collections.Generic;
using Data.Models;
using Domain.Models;
using ReactiveTypes;

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
            foreach (KeyValuePair<ModelPropertyName, IReactivePropertyReadonlyUntyped> pair in model.Properties)
            {
                IReactivePropertyReadonlyUntyped property = pair.Value;

                if (!modelData.PropertiesData.ContainsKey(pair.Key))
                {
                    modelData.PropertiesData[pair.Key] = new ModelPropertyData();
                }
                
                ModelPropertyData propertyData = modelData.PropertiesData[pair.Key];
                object modelPropertyValue = property.Value;
                
                propertyData.ValueTypeName = ValueTypeName.Bool.GetValueTypeName(modelPropertyValue);
                propertyData.SerializedValue = _serializeService.Serialize(modelPropertyValue);
            }

            foreach (KeyValuePair<ModelListName, IReactiveListReadOnlyUntyped> pair in model.Lists)
            {
                IReactiveListReadOnlyUntyped list = pair.Value;
                
                
                
            }
        }
    }
}