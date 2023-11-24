using Repositories.Configs;
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
        [SerializeField] private WeaponConfig defaultWeaponConfig;

        public float MaxHealth => _maxHealth;
        public float Protection => _protection;
        public float Speed => _speed;
        public float RotationSpeed => _rotationSpeed;
    }
}