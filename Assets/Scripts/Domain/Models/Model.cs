using System.Collections.Generic;
using ReactiveTypes;

namespace Domain.Models
{
    public class Model : IModel
    {
        public IDictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped> Properties { get; }
        public IDictionary<ModelListName, IReactiveListReadOnlyUntyped> Lists { get; }
        public IReactiveProperty<T> GetProperty<T>(ModelPropertyName propertyName) => (IReactiveProperty<T>)Properties[propertyName];
        public IReactiveList<T> GetList<T>(ModelListName listName) => (IReactiveList<T>)Lists[listName];

        public Model(
            IDictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped> properties,
            IDictionary<ModelListName, IReactiveListReadOnlyUntyped> lists)
        {
            Properties = properties;
            Lists = lists;
        }
    }
}