using UnityEngine;

namespace Features.Damager
{
    public class DamagerViewFacade : BaseViewFacade
    {
        [SerializeField]
        private DamagerPhysics _damagerPhysics;

        public DamagerPhysics DamagerPhysics => _damagerPhysics;
    }
}