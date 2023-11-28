using System;
using ReactiveTypes;

namespace Domain.Logic.Damageable
{
    public class DamageableLogic : IDamageableLogic
    {
        private readonly IReactiveProperty<float> _health;
        private readonly float _protection;

        public DamageableLogic(IReactiveProperty<float> health, float protection)
        {
            _health = health;
            _protection = protection;
        }

        public event Action<IDamageableLogic> Died;

        public void GetDamage(float damage)
        {
            float difference = _health.Value - (damage * _protection);
            _health.Value = difference < 0f ? 0f : difference;
        }
    }
}