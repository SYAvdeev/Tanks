using System;
using Common;
using Services.Factory.Features;

namespace Configs.Feature
{
    [Serializable]
    public class FeatureConfigsDictionary : UnitySerializedDictionary<string, FeatureConfig>
    {
        
    }
}