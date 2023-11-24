using System;

namespace Data.Models
{
    public enum ModelPropertyValueTypeName
    {
        Bool,
        Int,
        Float,
        String
    }
    
    public static class ModelPropertyValueTypeExtensions
    {
        public static Type GetPropertyValueType(this ModelPropertyValueTypeName valueTypeName) =>
            valueTypeName switch
            {
                ModelPropertyValueTypeName.Int => typeof(int),
                ModelPropertyValueTypeName.Float => typeof(float),
                ModelPropertyValueTypeName.String => typeof(string),
                ModelPropertyValueTypeName.Bool => typeof(bool),
                _ => throw new ArgumentOutOfRangeException(nameof(valueTypeName), valueTypeName, null)
            };

        public static ModelPropertyValueTypeName GetValueTypeName(this ModelPropertyValueTypeName valueTypeName, object value) =>
            value switch
            {
                int => ModelPropertyValueTypeName.Int,
                float => ModelPropertyValueTypeName.Float,
                string => ModelPropertyValueTypeName.String,
                bool => ModelPropertyValueTypeName.Bool,
                _ => throw new ArgumentOutOfRangeException(nameof(value))
            };
    }
}