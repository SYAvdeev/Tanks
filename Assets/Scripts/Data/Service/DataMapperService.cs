using System;
using System.Collections.Generic;
using Data.Models;
using Domain.Models;
using ReactiveTypes;

namespace Data.Service
{
    public class DataMapperService : IDataMapperService
    {
        private readonly IDataSerializeService _serializeService;

        public DataMapperService(IDataSerializeService serializeService)
        {
            _serializeService = serializeService;
        }

        public void MapModelToData(IModel model, IModelData modelData)
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

            foreach (KeyValuePair<ModelPropertyName, ModelPropertyData> pair in modelData.PropertiesData)
            {
                if (!model.Properties.ContainsKey(pair.Key))
                {
                    modelData.PropertiesData.Remove(pair.Key);
                }
            }

            foreach (KeyValuePair<ModelListName, IReactiveListReadOnlyUntyped> pair in model.Lists)
            {
                IReactiveListReadOnlyUntyped list = pair.Value;
                
                if (!modelData.ListsData.ContainsKey(pair.Key))
                {
                    modelData.ListsData[pair.Key] = new ModelListData();
                }
                
                ModelListData listData = modelData.ListsData[pair.Key];
                
                listData.ValueTypeName = ValueTypeName.Bool.GetCollectionTypeName(list);
                
                //object modelPropertyValue = list.Value;
                
                //listData.ValueTypeName = ValueTypeName.Bool.GetValueTypeName(modelPropertyValue);

                for (int i = 0; i < list.Count; i++)
                {
                    
                }
                
                //listData.SerializedValue = _serializeService.Serialize(list);
            }
            
            foreach (KeyValuePair<ModelListName, IReactiveListReadOnlyUntyped> pair in model.Lists)
            {
                if (!model.Lists.ContainsKey(pair.Key))
                {
                    modelData.ListsData.Remove(pair.Key);
                }
            }
        }

        public void MapDataToModel(IModelData modelData, IModel model)
        {
            
        }

        public void MapModelToData(IModelData modelData, IModel model)
        {
            throw new NotImplementedException();
        }
    }
}