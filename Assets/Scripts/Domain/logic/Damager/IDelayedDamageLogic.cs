using Domain.Logic.Damageable;
using Domain.Logic.Delayed;

namespace Domain.Logic.Damager
{
    public interface IDelayedDamageLogic : IDelayedActionLogic
    {
        void SetTarget(IDamageableLogic target);
    }
}