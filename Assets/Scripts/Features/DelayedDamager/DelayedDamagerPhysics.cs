using System;
using System.Collections.Generic;
using Features.Damageable;
using UnityEngine;

namespace Features.DelayedDamager
{
    public class DelayedDamagerPhysics : MonoBehaviour
    {
        [SerializeField]
        private List<string> _damageableTags;
        
        public event Action<DamageablePhysics> CollisionEnterWithDamageable;
        public event Action CollisionExitWithDamageable;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collisionGameObject = collision.gameObject;
            
            for (int i = 0; i < _damageableTags.Count; i++)
            {
                if (collisionGameObject.CompareTag(_damageableTags[i]))
                {
                    DamageablePhysics damageablePhysics = collisionGameObject.GetComponent<DamageablePhysics>();
                    CollisionEnterWithDamageable?.Invoke(damageablePhysics);
                    return;
                }
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            GameObject collisionGameObject = other.gameObject;
            
            for (int i = 0; i < _damageableTags.Count; i++)
            {
                if (collisionGameObject.CompareTag(_damageableTags[i]))
                {
                    CollisionExitWithDamageable?.Invoke();
                    return;
                }
            }
        }
    }
}