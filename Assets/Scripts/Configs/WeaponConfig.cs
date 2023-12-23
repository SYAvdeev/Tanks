using UnityEngine;

namespace Configs
{
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _damage;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _reloadDelay;
        [SerializeField] private GameObject _prefab;

        public string Name => _name;
        public float Damage => _damage;
        public float BulletSpeed => _bulletSpeed;
        public float ReloadDelay => _reloadDelay;
        public GameObject Prefab => _prefab;
    }
}