using System.Collections.Generic;
using Tanks.Game.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Player
{
    [CreateAssetMenu(
        fileName = nameof(PlayerConfig),
        menuName = "Custom/Game/LevelObjects/" + nameof(PlayerConfig),
        order = 4)]
    public class PlayerConfig : ConfigBase, IPlayerConfig
    {
        [SerializeField] private WeaponConfig[] _weaponConfig;
        [SerializeField] private MovableConfig _movableConfig;
        [SerializeField] private DamageableConfig _damageableConfig;
        [SerializeField] private float _rotationVelocity;
        [SerializeField] private WeaponConfig _firstWeaponConfig;
        [SerializeField] private Vector2 _initialPosition;

        public IReadOnlyList<WeaponConfig> WeaponConfigs => _weaponConfig;
        public IMovableConfig MovableConfig => _movableConfig;
        public IDamageableConfig DamageableConfig => _damageableConfig;
        public float RotationVelocity => _rotationVelocity;
        public IWeaponConfig FirstWeaponConfig => _firstWeaponConfig;
        public Vector2 InitialPosition => _initialPosition;
    }
}