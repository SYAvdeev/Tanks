using System;
using ReactiveTypes;

namespace Domain.Models
{
    public class ModelProperty<T> : IModelProperty
    {
        public event Action<object> ValueChanged;
        public IReactiveProperty<T> Property { get; }

        public object Value => Property.Value;

        public ModelProperty(T value)
        {
            Property = new ReactiveProperty<T>(value);
            Property.OnValueChanged += PropertyOnOnValueChanged;
        }

        private void PropertyOnOnValueChanged(T obj)
        {
            ValueChanged?.Invoke(obj);
        }
    }
}