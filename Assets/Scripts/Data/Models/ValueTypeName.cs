using System;

namespace Data.Models
{
    public enum ValueTypeName
    {
        Bool,
        Int,
        Float,
        String
    }
    
    public static class ModelPropertyValueTypeExtensions
    {
        public static Type GetPropertyValueType(this ValueTypeName valueTypeName) =>
            valueTypeName switch
            {
                ValueTypeName.Int => typeof(int),
                ValueTypeName.Float => typeof(float),
                ValueTypeName.String => typeof(string),
                ValueTypeName.Bool => typeof(bool),
                _ => throw new ArgumentOutOfRangeException(nameof(valueTypeName), valueTypeName, null)
            };

        public static ValueTypeName GetValueTypeName(this ValueTypeName valueTypeName, object value) =>
            value switch
            {
                int => ValueTypeName.Int,
                float => ValueTypeName.Float,
                string => ValueTypeName.String,
                bool => ValueTypeName.Bool,
                _ => throw new ArgumentOutOfRangeException(nameof(value))
            };
    }
}