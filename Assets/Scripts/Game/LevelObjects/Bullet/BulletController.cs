using Tanks.Enemy;
using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletController : IBulletController
    {
        private readonly BulletView _bulletView;
        private readonly IBulletService _bulletService;

        public BulletController(BulletView bulletView, IBulletService bulletService)
        {
            _bulletView = bulletView;
            _bulletService = bulletService;
        }

        public void Initialize()
        {
            _bulletView.CollidedWithEnemy += BulletViewOnCollidedWithEnemy;
            _bulletService.BulletModel.Movable.PositionUpdated += MovableOnPositionUpdated;
            _bulletService.BulletModel.Movable.DirectionAngleUpdated += MovableOnDirectionAngleUpdated;
        }

        private void MovableOnDirectionAngleUpdated(float directionAngle)
        {
            _bulletView.transform.localRotation = Quaternion.Euler(0f, 0f, directionAngle);
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _bulletView.transform.localPosition = position;
        }

        private void BulletViewOnCollidedWithEnemy(EnemyView enemyView)
        {
            enemyView.CollidedWithDamager(_bulletService.BulletModel.Damager.Config.Damage);
        }

        public void Dispose()
        {
            _bulletView.CollidedWithEnemy -= BulletViewOnCollidedWithEnemy;
            _bulletService.BulletModel.Movable.PositionUpdated -= MovableOnPositionUpdated;
            _bulletService.BulletModel.Movable.DirectionAngleUpdated -= MovableOnDirectionAngleUpdated;
        }
    }
}