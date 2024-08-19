using System;
using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Bullet
{
    public class BulletView : MonoBehaviour
    {
        private const string EnemyTag = "Enemy";

        internal event Action<DamageableView> CollidedWithDamageable;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(EnemyTag))
            {
                var enemyView = other.gameObject.GetComponent<DamageableView>();
                CollidedWithDamageable?.Invoke(enemyView);
            }
        }
    }
}