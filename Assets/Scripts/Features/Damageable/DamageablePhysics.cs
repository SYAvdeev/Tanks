using Domain.Logic.Damageable;
using UnityEngine;

namespace Features.Damageable
{
    public class DamageablePhysics : MonoBehaviour
    {
        public IDamageableLogic DamageableLogic { get; private set; }

        public void Initialize(IDamageableLogic damageableLogic)
        {
            DamageableLogic = damageableLogic;
        }
    }
}