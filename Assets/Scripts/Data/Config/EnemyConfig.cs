using Model.LevelObjects.Config;
using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Enemy Config", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _damage;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _protection;
        [SerializeField] private float _speed;
        [SerializeField] private float _attackDelay;
        [SerializeField] private GameObject _prefab;
        private EnemyModelConfig _cachedEnemyModelConfig;

        public string Name => _name;
        public float Damage => _damage;
        public float MaxHealth => _maxHealth;
        public float Protection => _protection;
        public float Speed => _speed;
        public float AttackDelay => _attackDelay;
        public GameObject Prefab => _prefab;
        
        
        public EnemyModelConfig ToEnemyModelConfig() =>_cachedEnemyModelConfig ??= 
            new EnemyModelConfig(_name, _damage, _maxHealth, _protection, _speed, _attackDelay);
    }
}