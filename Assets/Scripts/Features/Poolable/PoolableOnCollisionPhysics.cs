using System.Collections.Generic;
using UnityEngine;

namespace Features.Poolable
{
    public class PoolableOnCollisionPhysics : MonoBehaviour
    {
        public PoolableViewModel PoolableViewModel { get; private set; }
        private List<string> _collisionTags;

        public void Initialize(PoolableViewModel poolableViewModel, List<string> collisionTags)
        {
            PoolableViewModel = poolableViewModel;
            _collisionTags = collisionTags;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collisionGameObject = collision.gameObject;
            
            for (int i = 0; i < _collisionTags.Count; i++)
            {
                if (collisionGameObject.CompareTag(_collisionTags[i]))
                {
                    PoolableViewModel.AddToPool();
                    return;
                }
            }
        }
    }
}