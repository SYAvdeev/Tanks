using System;
using ReactiveTypes;

namespace Domain.Logic.Damageable
{
    public class DamageableLogic : IDamageableLogic
    {
        private readonly IReactiveProperty<float> _healthProperty;
        private readonly IReactivePropertyReadonly<float> _protectionProperty;

        public event Action Died;

        public DamageableLogic(IReactiveProperty<float> healthProperty, IReactivePropertyReadonly<float> protectionProperty)
        {
            _healthProperty = healthProperty;
            _protectionProperty = protectionProperty;
        }

        public void GetDamage(float damage)
        {
            float difference = _healthProperty.Value - (damage * _protectionProperty.Value);
            if (difference < 0f)
            {
                _healthProperty.Value = 0f;
                Died?.Invoke();
            }
            else
            {
                _healthProperty.Value = difference;
            }
        }
    }
}