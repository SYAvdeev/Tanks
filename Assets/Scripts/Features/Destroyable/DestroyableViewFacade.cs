using UnityEngine;

namespace Features.Destroyable
{
    public class DestroyableViewFacade : BaseViewFacade
    {
        [SerializeField]
        private DestroyableOnCollisionPhysics _destroyableOnCollisionPhysics;

        public DestroyableOnCollisionPhysics DestroyableOnCollisionPhysics => _destroyableOnCollisionPhysics;
    }
}