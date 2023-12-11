using Domain.Logic.Damageable;
using ReactiveTypes;

namespace Domain.Logic.Damager
{
    public class DamagerLogic : IDamagerLogic
    {
        public IReactivePropertyReadonly<float> DamageProperty { get; }

        public DamagerLogic(IReactivePropertyReadonly<float> damageProperty)
        {
            DamageProperty = damageProperty;
        }

        public void Damage(IDamageableLogic damageable)
        {
            damageable.GetDamage(DamageProperty.Value);
        }
    }
}