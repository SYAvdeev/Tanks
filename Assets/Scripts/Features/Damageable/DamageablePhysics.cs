using UnityEngine;

namespace Features.Damageable
{
    public class DamageablePhysics : MonoBehaviour
    {
        public DamageableViewModel DamageableViewModel { get; private set; }

        public void Initialize(DamageableViewModel damageableViewModel)
        {
            DamageableViewModel = damageableViewModel;
        }
    }
}