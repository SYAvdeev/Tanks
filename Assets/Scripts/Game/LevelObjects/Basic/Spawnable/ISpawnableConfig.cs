using UnityEngine.AddressableAssets;

namespace Tanks.Game.LevelObjects.Basic
{
    public interface ISpawnableConfig
    {
        string ID { get; }
        AssetReference AssetReference { get; }
    }
}