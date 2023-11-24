using System.Collections.Generic;

namespace Domain.Models
{
    public class Model : IModel
    {
        public IDictionary<string, IModelProperty> ModelProperties { get; }
        
        public Model(IDictionary<string, IModelProperty> modelProperties)
        {
            ModelProperties = modelProperties;
        }
    }
}