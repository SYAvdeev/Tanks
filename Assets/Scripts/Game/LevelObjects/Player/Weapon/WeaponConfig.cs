using Tanks.Game.LevelObjects.Basic;
using Tanks.Game.LevelObjects.Bullet;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Player
{
    [CreateAssetMenu(
        fileName = nameof(WeaponConfig),
        menuName = "Custom/Game/LevelObjects/" + nameof(WeaponConfig),
        order = 5)]
    public class WeaponConfig : ConfigBase, IWeaponConfig
    {
        [SerializeField] private SpawnableConfig _spawnableConfig;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private float _reloadDelay;

        public ISpawnableConfig SpawnableConfig => _spawnableConfig;
        public IBulletConfig BulletConfig => _bulletConfig;
        public float ReloadDelay => _reloadDelay;
    }
}