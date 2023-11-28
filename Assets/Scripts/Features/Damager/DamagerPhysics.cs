using System.Collections.Generic;
using Features.Damageable;
using UnityEngine;

namespace Features.Damager
{
    public class DamagerPhysics : MonoBehaviour
    {
        private DamagerViewModel _damagerViewModel;
        private List<string> _damageableTags;

        public void Initialize(DamagerViewModel damagerViewModel, List<string> damageableTags)
        {
            _damagerViewModel = damagerViewModel;
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
                    _damagerViewModel.Damage(damageablePhysics.DamageableViewModel.DamageableLogic);
                    return;
                }
            }
        }
    }
}