using System;
using ReactiveTypes;

namespace Domain.Logic.Damageable
{
    public class DamageableLogic : IDamageableLogic
    {
        private readonly IReactiveProperty<float> _health;
        private readonly float _protection;
        private readonly float _minHealth;

        public DamageableLogic(IReactiveProperty<float> health, float protection, float minHealth)
        {
            _health = health;
            _protection = protection;
            _minHealth = minHealth;
        }

        public event Action<IDamageableLogic> Died;

        public void GetDamage(float damage)
        {
            float difference = _health.Value - (damage * _protection);
            _health.Value = difference < _minHealth ? _minHealth : difference;
        }
    }
}