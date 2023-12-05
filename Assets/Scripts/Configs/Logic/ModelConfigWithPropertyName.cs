using System;
using Configs.Model;

namespace Configs.Logic
{
    [Serializable]
    public class ModelConfigWithPropertyName
    {
        public ModelConfig ModelConfig;
        public string PropertyName;
    }
}