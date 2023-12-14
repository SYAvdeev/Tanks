using System;
using System.Collections.Generic;
using Features.Damageable;
using UnityEngine;

namespace Features.Damager
{
    public class DamagerPhysics : MonoBehaviour
    {
        [SerializeField]
        private List<string> _damageableTags;

        public event Action<DamageablePhysics> CollisionWithDamageable;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collisionGameObject = collision.gameObject;
            
            for (int i = 0; i < _damageableTags.Count; i++)
            {
                if (collisionGameObject.CompareTag(_damageableTags[i]))
                {
                    DamageablePhysics damageablePhysics = collisionGameObject.GetComponent<DamageablePhysics>();
                    CollisionWithDamageable?.Invoke(damageablePhysics);
                    return;
                }
            }
        }
    }
}