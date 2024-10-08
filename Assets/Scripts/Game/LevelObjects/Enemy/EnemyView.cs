﻿using System;
using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private const string PlayerTag = "Player";
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private SpriteRenderer _healthSpriteRenderer;
        [SerializeField] private DamageableView _damageableView;
        [SerializeField] private float _healthBarMaxWidth;

        public Transform RotateTransform => _rotateTransform;
        public SpriteRenderer HealthSpriteRenderer => _healthSpriteRenderer;
        public DamageableView DamageableView => _damageableView;
        public float HealthBarMaxWidth => _healthBarMaxWidth;

        internal event Action<DamageableView> CollidedWithDamageable;
        internal event Action<DamageableView> CollisionWithDamageableEnded;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                var enemyView = other.gameObject.GetComponent<DamageableView>();
                CollidedWithDamageable?.Invoke(enemyView);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(PlayerTag))
            {
                var enemyView = other.gameObject.GetComponent<DamageableView>();
                CollisionWithDamageableEnded?.Invoke(enemyView);
            }
        }
    }
}