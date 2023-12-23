using Domain.Logic.Damageable;
using ReactiveTypes;

namespace Domain.Logic.Damager
{
    public class DamagerLogic : IDamagerLogic
    {
        private readonly IReactivePropertyReadonly<float> _damageProperty;

        public DamagerLogic(IReactivePropertyReadonly<float> damageProperty)
        {
            _damageProperty = damageProperty;
        }

        public void Damage(IDamageableLogic damageable)
        {
            damageable.GetDamage(_damageProperty.Value);
        }
    }
}