using System.Collections.Generic;
using Features.Damageable;
using UnityEngine;

namespace Features.DelayedDamager
{
    public class DelayedDamagerPhysics : MonoBehaviour
    {
        private DelayedDamagerViewModel _delayedDamagerViewModel;
        private List<string> _damageableTags;

        public void Initialize(DelayedDamagerViewModel delayedDamagerViewModel, List<string> damageableTags)
        {
            _delayedDamagerViewModel = delayedDamagerViewModel;
            _damageableTags = damageableTags;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collisionGameObject = collision.gameObject;
            
            for (int i = 0; i < _damageableTags.Count; i++)
            {
                if (collisionGameObject.CompareTag(_damageableTags[i]))
                {
                    DamageablePhysics damageablePhysics = collisionGameObject.GetComponent<DamageablePhysics>();
                    _delayedDamagerViewModel.StartDelayedDamageLogic(damageablePhysics.DamageableViewModel.DamageableLogic);
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
                    _delayedDamagerViewModel.StopDelayedDamageLogic();
                    return;
                }
            }
        }
    }
}