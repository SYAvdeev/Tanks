using Tanks.Game.LevelObjects.Basic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Tanks.Game.LevelObjects.Level
{
    public interface ILevelConfig
    {
        ISpawnableConfig SpawnableConfig { get; }
        Vector2 MinPosition { get; }
        Vector2 MaxPosition { get; }
    }
}