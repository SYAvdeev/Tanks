using System;
using Common;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Configs.Prototype
{
    [Serializable]
    public class PrototypeDictionary : UnitySerializedDictionary<string, IResourceLocation> { }
}