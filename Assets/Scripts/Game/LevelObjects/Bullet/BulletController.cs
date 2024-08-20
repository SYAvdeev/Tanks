using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Bullet
{
    public class BulletController : IBulletController
    {
        private readonly BulletView _bulletView;

        public BulletController(BulletView bulletView, IBulletService bulletService)
        {
            _bulletView = bulletView;
            BulletService = bulletService;
            
            _bulletView.CollidedWithDamageable += BulletViewOnCollidedWithDamageable;
            BulletService.BulletModel.Movable.PositionUpdated += MovableOnPositionUpdated;
            BulletService.BulletModel.Movable.DirectionAngleUpdated += MovableOnDirectionAngleUpdated;
        }

        public IBulletService BulletService { get; }

        private void MovableOnDirectionAngleUpdated(float directionAngle)
        {
            _bulletView.transform.localRotation = Quaternion.Euler(0f, 0f, directionAngle);
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _bulletView.transform.localPosition = position;
        }

        private void BulletViewOnCollidedWithDamageable(DamageableView damageableView)
        {
            damageableView.CollideWithDamager(BulletService.DamagerService);
        }

        public void Dispose()
        {
            _bulletView.CollidedWithDamageable -= BulletViewOnCollidedWithDamageable;
            BulletService.BulletModel.Movable.PositionUpdated -= MovableOnPositionUpdated;
            BulletService.BulletModel.Movable.DirectionAngleUpdated -= MovableOnDirectionAngleUpdated;
        }
    }
}