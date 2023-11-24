using Domain.Logic.Damageable;

namespace Domain.Logic.Damager
{
    public class DamagerLogic : IDamagerLogic
    {
        public void SetDamage(float damage, IDamageableLogic damageable)
        {
            damageable.GetDamage(damage);
        }
    }
}