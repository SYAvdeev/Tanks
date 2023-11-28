using System.Collections.Generic;
using Domain.Models;

namespace Data.Models
{
    public interface IModelData
    {
        IDictionary<ModelPropertyName, ModelPropertyData> PropertiesData { get; }
        IDictionary<ModelListName, >
    }
}