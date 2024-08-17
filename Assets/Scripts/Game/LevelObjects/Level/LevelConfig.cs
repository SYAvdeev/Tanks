using Tanks.Game.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Tanks.Game.LevelObjects.Level
{
    [CreateAssetMenu(
        fileName = nameof(LevelConfig), 
        menuName = "Custom/Game/LevelObjects/" + nameof(LevelConfig),
        order = 0)]
    public class LevelConfig : ConfigBase, ILevelConfig
    {
        [SerializeField] private SpawnableConfig _spawnableConfig;
        [SerializeField] private Vector2 _minPosition;
        [SerializeField] private Vector2 _maxPosition;

        public ISpawnableConfig SpawnableConfig => _spawnableConfig;
        public Vector2 MinPosition => _minPosition;
        public Vector2 MaxPosition => _maxPosition;
    }
}