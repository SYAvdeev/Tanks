using Domain.LevelObjects.Config;
using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Player Config", order = 2)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _protection;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private WeaponConfig _defaultWeaponConfig;
        private PlayerModelConfig _cachedPlayerModelConfig;

        public float MaxHealth => _maxHealth;
        public float Protection => _protection;
        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;

        public PlayerModelConfig ToPlayerModelConfig() => _cachedPlayerModelConfig ??= new PlayerModelConfig(_maxHealth,
                _protection, _speed, _rotationSpeed, _defaultWeaponConfig.ToWeaponModelConfig());
    }
}