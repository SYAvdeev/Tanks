using System;
using System.Collections.Generic;
using UnityEngine;

namespace Features.Destroyable
{
    public class DestroyableOnCollisionPhysics : MonoBehaviour
    {
        [SerializeField]
        private List<string> _collisionTags;

        public event Action Collision;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collisionGameObject = collision.gameObject;
            
            for (int i = 0; i < _collisionTags.Count; i++)
            {
                if (collisionGameObject.CompareTag(_collisionTags[i]))
                {
                    Collision?.Invoke();
                    return;
                }
            }
        }
    }
}