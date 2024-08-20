using Tanks.Game.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Tanks.Game.LevelObjects.Bullet
{
    [CreateAssetMenu(
        fileName = nameof(BulletConfig),
        menuName = "Custom/Game/LevelObjects/" + nameof(BulletConfig),
        order = 1)]
    public class BulletConfig : ConfigBase, IBulletConfig
    {
        [SerializeField] private MovableConfig _movableConfig;
        [SerializeField] private DamagerConfig _damagerConfig;
        [SerializeField] private SpawnableConfig _spawnableConfig;

        public ISpawnableConfig SpawnableConfig => _spawnableConfig;
        public IMovableConfig MovableConfig => _movableConfig;
        public IDamagerConfig DamagerConfig => _damagerConfig;
    }
}