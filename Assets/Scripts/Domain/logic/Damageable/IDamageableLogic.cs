using System;

namespace Domain.Logic.Damageable
{
    public interface IDamageableLogic
    {
        event Action<IDamageableLogic> Died;
        void GetDamage(float damage);
    }
}