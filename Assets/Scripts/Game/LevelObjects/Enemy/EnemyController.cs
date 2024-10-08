﻿using Tanks.Game.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Enemy
{
    public class EnemyController : IEnemyController
    {
        private readonly EnemyView _enemyView;
        public IEnemyService EnemyService { get; }
        
        private readonly UniTaskRestartable _updateTask;

        public EnemyController(IEnemyService enemyService, EnemyView enemyView)
        {
            EnemyService = enemyService;
            _enemyView = enemyView;
            EnemyService.Model.Movable.PositionUpdated += MovableOnPositionUpdated;
            EnemyService.Model.Movable.DirectionAngleUpdated += MovableOnDirectionAngleUpdated;
            EnemyService.Model.Damageable.HealthChanged += DamageableOnHealthChanged;
            _enemyView.DamageableView.CollidedWithDamager += DamageableViewOnCollidedWithDamager;
            _enemyView.CollidedWithDamageable += EnemyViewOnCollidedWithDamageable;
            _enemyView.CollisionWithDamageableEnded += EnemyViewOnCollisionWithDamageableEnded;
        }

        public void SetActive(bool isActive)
        {
            _enemyView.gameObject.SetActive(isActive);
        }

        private void EnemyViewOnCollisionWithDamageableEnded(DamageableView damageableView)
        {
            EnemyService.Model.SetState(EnemyState.Move);
        }

        private void EnemyViewOnCollidedWithDamageable(DamageableView damageableView)
        {
            EnemyService.Model.SetState(EnemyState.Attack);
        }

        private void DamageableViewOnCollidedWithDamager(IDamagerService damagerService)
        {
            damagerService.MakeDamage(EnemyService.DamageableService);
        }

        private void DamageableOnHealthChanged(float health)
        {
            float maxHealth = EnemyService.Model.Config.DamageableConfig.MaxHealth;
            var size = _enemyView.HealthSpriteRenderer.size;
            size.x = _enemyView.HealthBarMaxWidth * (health / maxHealth);
            _enemyView.HealthSpriteRenderer.size = size;
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _enemyView.transform.localPosition = position;
        }

        private void MovableOnDirectionAngleUpdated(float directionAngle)
        {
            _enemyView.RotateTransform.localRotation = Quaternion.Euler(0f, 0f, -directionAngle);
        }

        public void Dispose()
        {
            EnemyService.Model.Movable.PositionUpdated -= MovableOnPositionUpdated;
            EnemyService.Model.Movable.DirectionAngleUpdated -= MovableOnDirectionAngleUpdated;
            EnemyService.Model.Damageable.HealthChanged -= DamageableOnHealthChanged;
            _enemyView.DamageableView.CollidedWithDamager -= DamageableViewOnCollidedWithDamager;
            _enemyView.CollidedWithDamageable += EnemyViewOnCollidedWithDamageable;
        }
    }
}