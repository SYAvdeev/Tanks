using System;

namespace ReactiveTypes
{
    public interface IReactiveProperty<T> : IReactivePropertyReadonly<T>
    {
        T Value { get; set; }
    }

    public interface IReactivePropertyReadonly<T>
    {
        event Action<T> OnValueChanged;
        event Action<T, T> OnValueChangedExtended;
        T Value { get; }
    }

    public enum TypeDispatchEventMode
    {
        Always,
        ValueChange,
    }

    public class ReactiveProperty<T> : IReactiveProperty<T>, IReactivePropertyReadonly<T>
    {
        private T _value;
        private readonly TypeDispatchEventMode _dispatchEventMode;

        public ReactiveProperty(TypeDispatchEventMode dispatchEventMode = TypeDispatchEventMode.ValueChange)
        {
            _dispatchEventMode = dispatchEventMode;
        }

        public ReactiveProperty(T value, TypeDispatchEventMode dispatchEventMode = TypeDispatchEventMode.ValueChange)
            : this()
        {
            _value = value;
            _dispatchEventMode = dispatchEventMode;
        }

        public event Action<T> OnValueChanged;
        public event Action<T, T> OnValueChangedExtended;

        public T Value
        {
            get => _value;
            set
            {
                if (_value == null        ||
                    !_value.Equals(value) ||
                    _dispatchEventMode == TypeDispatchEventMode.Always)
                {
                    T oldValue = _value;
                    _value = value;

                    OnValueChanged?.Invoke(_value);
                    OnValueChangedExtended?.Invoke(oldValue, value);
                }
            }
        }

        public override string ToString()
        {
            return _value != null ? _value.ToString() : "NULL value";
        }

        public static implicit operator T(ReactiveProperty<T> value)
        {
            return value._value;
        }
    }
}
