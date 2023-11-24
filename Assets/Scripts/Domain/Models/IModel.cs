using System.Collections.Generic;

namespace Domain.Models
{
    public interface IModel
    {
        IDictionary<string, IModelProperty> ModelProperties { get; }
    }
}