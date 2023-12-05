using Domain.Logic.Damageable;
using Domain.Models;
using Services;

namespace Features.Poolable
{
    public class PoolableDamageableViewModel : PoolableViewModel
    {
        private readonly IDamageableLogic _damageableLogic;

        public PoolableDamageableViewModel(IModel model, IPoolService poolService, IDamageableLogic damageableLogic) : base(model, poolService)
        {
            _damageableLogic = damageableLogic;
            damageableLogic.Died += AddToPool;
        }
    }
}