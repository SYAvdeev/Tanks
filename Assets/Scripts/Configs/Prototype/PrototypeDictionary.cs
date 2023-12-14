using System;
using Common;
using UnityEngine.AddressableAssets;

namespace Configs.Prototype
{
    [Serializable]
    public class PrototypeDictionary : UnitySerializedDictionary<string, AssetReference > { }
}