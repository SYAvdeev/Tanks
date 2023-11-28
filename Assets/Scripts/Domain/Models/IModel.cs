using System.Collections.Generic;
using ReactiveTypes;

namespace Domain.Models
{
    public interface IModel
    {
        IDictionary<ModelPropertyName, IReactivePropertyReadonlyUntyped> Properties { get; }
        public IDictionary<ModelListName, IReactiveListReadOnlyUntyped> Lists { get; }
        ReactiveProperty<T> GetProperty<T>(ModelPropertyName propertyName);
        ReactiveList<T> GetList<T>(ModelListName listName);
    }
}