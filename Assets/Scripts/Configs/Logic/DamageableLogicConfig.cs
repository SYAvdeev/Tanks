using UnityEngine;

namespace Configs.Logic
{
    public class DamageableLogicConfig : LogicConfig
    {
        [SerializeField]
        private float _damage;
        [SerializeField]
        private float _protection;
        [SerializeField]
        private float _minHealth;
        [SerializeField]
        private string _healthPropertyName;

        public float Damage => _damage;
        public float Protection => _protection;
        public float MinHealth => _minHealth;
        public string HealthPropertyName => _healthPropertyName;
    }
}