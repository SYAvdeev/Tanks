using Domain.Logic.Damageable;

namespace Domain.Logic.Damager
{
    public interface IDamagerLogic
    {
        void SetDamage(float damage, IDamageableLogic damageable);
    }
}