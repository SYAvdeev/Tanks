using UnityEngine;

namespace Features.DelayedDamager
{
    public class DelayedDamagerViewFacade : BaseViewFacade
    {
        [SerializeField]
        private DelayedDamagerPhysics _delayedDamagerPhysics;

        public DelayedDamagerPhysics DelayedDamagerPhysics => _delayedDamagerPhysics;
    }
}