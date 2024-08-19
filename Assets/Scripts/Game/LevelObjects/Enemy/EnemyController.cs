using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Enemy
{
    public class EnemyController : IEnemyController
    {
        private readonly EnemyView _enemyView;
        public IEnemyService EnemyService { get; }

        public EnemyController(IEnemyService enemyService, EnemyView enemyView)
        {
            EnemyService = enemyService;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            EnemyService.Model.Movable.PositionUpdated += MovableOnPositionUpdated;
            EnemyService.Model.Movable.DirectionAngleUpdated += MovableOnDirectionAngleUpdated;
            EnemyService.Model.Damageable.HealthChanged += DamageableOnHealthChanged;
            _enemyView.DamageableView.CollidedWithDamager += DamageableViewOnCollidedWithDamager;
            _enemyView.CollidedWithDamageable += EnemyViewOnCollidedWithDamageable;
            _enemyView.CollisionWithDamageableEnded += EnemyViewOnCollisionWithDamageableEnded;
        }

        private void EnemyViewOnCollisionWithDamageableEnded(DamageableView damageableView)
        {
            EnemyService.Model.SetState(EnemyState.Move);
        }

        private void EnemyViewOnCollidedWithDamageable(DamageableView damageableView)
        {
            EnemyService.Model.SetState(EnemyState.Attack);
        }

        private void DamageableViewOnCollidedWithDamager(float damage)
        {
            EnemyService.DamageableService.ConsumeDamage(damage);
        }

        private void DamageableOnHealthChanged(float health)
        {
            var size = _enemyView.HealthSpriteRenderer.size;
            size.x = health;
            _enemyView.HealthSpriteRenderer.size = size;
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _enemyView.transform.localPosition = position;
        }

        private void MovableOnDirectionAngleUpdated(float directionAngle)
        {
            _enemyView.transform.localRotation = Quaternion.Euler(0f, 0f, directionAngle);
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