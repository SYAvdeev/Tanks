using System;
using Tanks.Enemy;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private const string EnemyTag = "Enemy";

        internal event Action<EnemyView> CollidedWithEnemy;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(EnemyTag))
            {
                var enemyView = other.gameObject.GetComponent<EnemyView>();
                CollidedWithEnemy?.Invoke(enemyView);
            }
        }
    }
}