using System;
using ReactiveTypes;

namespace Domain.Logic.Damageable
{
    public class DamageableLogic : IDamageableLogic
    {
        private readonly IReactiveProperty<float> _health;
        private readonly float _protection;

        public event Action Died;

        public DamageableLogic(IReactiveProperty<float> health, float protection)
        {
            _health = health;
            _protection = protection;
        }

        public void GetDamage(float damage)
        {
            float difference = _health.Value - (damage * _protection);
            if (difference < 0f)
            {
                _health.Value = 0f;
                Died?.Invoke();
            }
            else
            {
                _health.Value = difference;
            }
        }
    }
}