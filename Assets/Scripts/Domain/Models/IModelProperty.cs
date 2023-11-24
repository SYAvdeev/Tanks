using System;

namespace Domain.Models
{
    public interface IModelProperty
    {
        object Value { get; }
        event Action<object> ValueChanged;
    }
}