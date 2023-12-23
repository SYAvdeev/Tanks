using System;

namespace Domain.Logic.Damageable
{
    public interface IDamageableLogic : ILogic
    {
        event Action Died;
        void GetDamage(float damage);
    }
}