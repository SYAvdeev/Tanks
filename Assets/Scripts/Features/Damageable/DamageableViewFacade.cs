using UnityEngine;

namespace Features.Damageable
{
    public class DamageableViewFacade : BaseViewFacade
    {
        [SerializeField] 
        private Transform _healthTransform;
        [SerializeField]
        private DamageablePhysics _damageablePhysics;

        public Transform HealthTransform => _healthTransform;
        public DamageablePhysics DamageablePhysics => _damageablePhysics;
    }
}