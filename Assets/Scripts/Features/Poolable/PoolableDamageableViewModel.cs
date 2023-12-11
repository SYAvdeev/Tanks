using Domain.Logic.Damageable;
using Domain.Models;
using Services.Pool;
using UnityEngine;

namespace Features.Poolable
{
    public class PoolableDamageableViewModel : PoolableViewModel
    {
        private readonly IDamageableLogic _damageableLogic;

        public PoolableDamageableViewModel(
            IModel model, 
            IPoolService<GameObject> poolService,
            IDamageableLogic damageableLogic,
            PoolableViewLogic poolableViewLogic) :
            base(model, poolService, poolableViewLogic)
        {
            _damageableLogic = damageableLogic;
            damageableLogic.Died += AddToPool;
        }
    }
}