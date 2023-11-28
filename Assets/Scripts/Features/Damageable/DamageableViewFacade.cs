using UnityEngine;

namespace Features.Damageable
{
    public class DamageableViewFacade : MonoBehaviour
    {
        [SerializeField] 
        private Transform _healthTransform;

        public Transform HealthTransform => _healthTransform;
    }
}