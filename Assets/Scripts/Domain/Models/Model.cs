using System.Collections.Generic;
using ReactiveTypes;

namespace Domain.Models
{
    public class Model : IModel
    {
        public IDictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped> Properties { get; }
        public IDictionary<ModelListName, IReactiveListReadOnlyUntyped> Lists { get; }
        public ReactiveProperty<T> GetProperty<T>(ModelPropertyName propertyName) => (ReactiveProperty<T>)Properties[propertyName];
        public ReactiveList<T> GetList<T>(ModelListName listName) => (ReactiveList<T>)Lists[listName];

        public Model(
            IDictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped> properties,
            IDictionary<ModelListName, IReactiveListReadOnlyUntyped> lists)
        {
            Properties = properties;
            Lists = lists;
        }
    }
}