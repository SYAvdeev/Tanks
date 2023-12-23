using System;
using System.Collections.Generic;

namespace Data.Models
{
    [Serializable]
    public class ModelListData
    {
        public ValueTypeName ValueTypeName;
        public List<string> SerializedValues;
    }
}