using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Enemy
{
    public class EnemyController : IEnemyController
    {
        private readonly IEnemyService _enemyService;
        private readonly EnemyView _enemyView;

        public EnemyController(IEnemyService enemyService, EnemyView enemyView)
        {
            _enemyService = enemyService;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            _enemyService.Model.MovableModel.PositionUpdated += MovableModelOnPositionUpdated;
            _enemyService.Model.MovableModel.DirectionAngleUpdated += MovableModelOnDirectionAngleUpdated;
            _enemyService.Model.DamageableModel.HealthChanged += DamageableOnHealthChanged;
            _enemyView.DamageableView.CollidedWithDamager += DamageableViewOnCollidedWithDamager;
            _enemyView.CollidedWithDamageable += EnemyViewOnCollidedWithDamageable;
            _enemyView.CollisionWithDamageableEnded += EnemyViewOnCollisionWithDamageableEnded;
        }

        private void EnemyViewOnCollisionWithDamageableEnded(DamageableView damageableView)
        {
            _enemyService.Model.SetState(EnemyState.Move);
        }

        private void EnemyViewOnCollidedWithDamageable(DamageableView damageableView)
        {
            _enemyService.Model.SetState(EnemyState.Attack);
        }

        private void DamageableViewOnCollidedWithDamager(float damage)
        {
            _enemyService.DamageableService.ConsumeDamage(damage);
        }

        private void DamageableOnHealthChanged(float health)
        {
            var size = _enemyView.HealthSpriteRenderer.size;
            size.x = health;
            _enemyView.HealthSpriteRenderer.size = size;
        }

        private void MovableModelOnPositionUpdated(Vector2 position)
        {
            _enemyView.transform.localPosition = position;
        }

        private void MovableModelOnDirectionAngleUpdated(float directionAngle)
        {
            _enemyView.transform.localRotation = Quaternion.Euler(0f, 0f, directionAngle);
        }

        public void Dispose()
        {
            _enemyService.Model.MovableModel.PositionUpdated -= MovableModelOnPositionUpdated;
            _enemyService.Model.MovableModel.DirectionAngleUpdated -= MovableModelOnDirectionAngleUpdated;
            _enemyService.Model.DamageableModel.HealthChanged -= DamageableOnHealthChanged;
            _enemyView.DamageableView.CollidedWithDamager -= DamageableViewOnCollidedWithDamager;
            _enemyView.CollidedWithDamageable += EnemyViewOnCollidedWithDamageable;
        }
    }
}