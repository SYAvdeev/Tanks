using System.Collections.Generic;

namespace Data.Models
{
    public interface IModelData
    {
        IDictionary<string, ModelPropertyData> PropertiesData { get; }
    }
}