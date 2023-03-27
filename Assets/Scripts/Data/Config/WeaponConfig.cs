using Domain.LevelObjects.Config;
using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Weapon Config", order = 3)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _damage;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _reloadDelay;
        [SerializeField] private GameObject _prefab;
        
        private WeaponModelConfig _cachedWeaponModelConfig;

        public string Name => _name;
        public float Damage => _damage;
        public float BulletSpeed => _bulletSpeed;
        public float ReloadDelay => _reloadDelay;
        public GameObject Prefab => _prefab;
        
        public WeaponModelConfig ToWeaponModelConfig() => _cachedWeaponModelConfig ??= new WeaponModelConfig(_name, _bulletSpeed, _reloadDelay, _damage);
    }
}