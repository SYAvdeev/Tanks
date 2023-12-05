using UnityEngine;

namespace Features.Poolable
{
    public class PoolableViewLogic
    {
        private readonly PoolableViewFacade _poolableViewFacade;
        private readonly PoolableViewModel _poolableViewModel;

        public GameObject PooledObject => _poolableViewFacade.PooledObject;
    }
}