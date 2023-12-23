using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Configs.Prototype
{
    [CreateAssetMenu(fileName ="AssetReferenceConfig", menuName = "Assets/Config/Asset Reference Config", order = 0)]
    public class AssetReferenceConfig : ScriptableObject
    {
        [SerializeField]
        private AssetReference assetReference;

        public AssetReference AssetReference => assetReference;
    }
}