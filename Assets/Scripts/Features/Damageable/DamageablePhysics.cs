using UnityEngine;

namespace Features.Damageable
{
    public class DamageablePhysics : MonoBehaviour
    {
        public DamageableViewLogic DamageableViewLogic { get; private set; }

        public void Initialize(DamageableViewLogic damageableViewLogic)
        {
            DamageableViewLogic = damageableViewLogic;
        }
    }
}