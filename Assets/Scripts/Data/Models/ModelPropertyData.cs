using System;

namespace Data.Models
{
    [Serializable]
    public class ModelPropertyData
    {
        public ModelPropertyValueTypeName ValueTypeNameName;
        public string SerializedValue;

        // public ModelPropertyData(ModelPropertyValueTypeName valueTypeName, string serializedValue)
        // {
        //     ValueTypeNameName = valueTypeName;
        //     SerializedValue = serializedValue;
        // }
    }
}