using Tanks.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Tanks.Game.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(SpawnableConfig), 
        menuName = "Custom/Game/LevelObjects/Basic/" + nameof(SpawnableConfig),
        order = 3)]
    public class SpawnableConfig : ConfigBase, ISpawnableConfig
    {
        [SerializeField] private string _id;
        [SerializeField] private AssetReference _assetReference;

        public string ID => _id;
        public AssetReference AssetReference => _assetReference;
    }
}