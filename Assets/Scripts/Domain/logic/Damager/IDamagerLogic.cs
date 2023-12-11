using Domain.Logic.Damageable;

namespace Domain.Logic.Damager
{
    public interface IDamagerLogic : ILogic
    {
        void Damage(IDamageableLogic damageable);
    }
}