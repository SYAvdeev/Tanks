using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Data.Models;
using Domain.Models;
using ReactiveTypes;

namespace Services.Factory.Model
{
    public class ModelFactory : IModelFactory
    {
        public IModel CreateModel(IModelData modelData)
        {
            IDictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped> modelProperties =
                new Dictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped>();
            
            IDictionary<ModelListName, IReactiveListReadOnlyUntyped> modelLists =
                new Dictionary<ModelListName, IReactiveListReadOnlyUntyped>();

            foreach (KeyValuePair<ModelPropertyName, ModelPropertyData> pair in modelData.PropertiesData)
            {
                modelProperties.Add(pair.Key, CreateModelProperty(pair.Value));
            }
            
            foreach (KeyValuePair<ModelListName, ModelListData> pair in modelData.ListsData)
            {
                modelLists.Add(pair.Key, CreateModelList(pair.Value));
            }

            return new Domain.Models.Model(modelProperties, modelLists);
        }
        
        public IReactivePropertyReadonlyUntyped CreateModelProperty(ModelPropertyData modelPropertyData) =>
            modelPropertyData.ValueTypeName switch
            {
                ValueTypeName.Bool => new ReactiveProperty<bool>(bool.Parse(modelPropertyData.SerializedValue)),
                ValueTypeName.Int => new ReactiveProperty<int>(int.Parse(modelPropertyData.SerializedValue)),
                ValueTypeName.Float => new ReactiveProperty<float>(float.Parse(modelPropertyData.SerializedValue, CultureInfo.InvariantCulture)),
                ValueTypeName.String => new ReactiveProperty<string>(modelPropertyData.SerializedValue),
                _ => throw new ArgumentOutOfRangeException()
            };

        public IReactiveListReadOnlyUntyped CreateModelList(ModelListData modelListData) =>
            modelListData.ValueTypeName switch
            {
                ValueTypeName.Bool =>
                    new ReactiveList<bool>(modelListData.SerializedValues.Select(bool.Parse).ToList()),
                ValueTypeName.Int => 
                    new ReactiveList<int>(modelListData.SerializedValues.Select(int.Parse).ToList()),
                ValueTypeName.Float =>
                    new ReactiveList<float>(modelListData.SerializedValues.Select(float.Parse).ToList()),
                ValueTypeName.String => 
                    new ReactiveList<string>(modelListData.SerializedValues),
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}