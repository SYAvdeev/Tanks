using Domain.Logic.Damageable;

namespace Domain.Logic.Damager
{
    public interface IDamagerLogic
    {
        void Damage(float damage, IDamageableLogic damageable);
    }
}