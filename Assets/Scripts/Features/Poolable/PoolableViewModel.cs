using Domain.Models;
using ReactiveTypes;
using Services;
using Services.Pool;
using UnityEngine;

namespace Features.Poolable
{
    public class PoolableViewModel : BaseViewModel
    {
        protected readonly IPoolService<GameObject> _poolService;
        protected readonly PoolableViewLogic _poolableViewLogic;
        
        public PoolableViewModel(IModel model, IPoolService<GameObject> poolService, PoolableViewLogic poolableViewLogic) : base(model)
        {
            _poolService = poolService;
            _poolableViewLogic = poolableViewLogic;
        }

        public void AddToPool()
        {
            GameObject pooledObject = _poolableViewLogic.PooledObject;
            IReactiveProperty<string> poolKey = _model.GetProperty<string>(ModelPropertyName.ViewKey);
            _poolService.Add(poolKey.Value, pooledObject);
        }
    }
}