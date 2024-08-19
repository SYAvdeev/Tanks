using System;
using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        [SerializeField] private DamageableView _damageableView;

        public DamageableView DamageableView => _damageableView;
        
        internal event Action<DamageableView> CollidedWithDamageable;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                var enemyView = other.gameObject.GetComponent<DamageableView>();
                CollidedWithDamageable?.Invoke(enemyView);
            }
        }
    }
}