using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Bullet
{
    public class BulletService : IBulletService
    {
        public IBulletModel BulletModel { get; }

        public IMovableService MovableService { get; }
        public IDamagerService DamagerService { get; }

        public event Action<IBulletService> Destroyed;

        public BulletService(IBulletModel bulletModel)
        {
            BulletModel = bulletModel;
            MovableService = new MovableService(bulletModel.Movable);
            DamagerService = new DamagerService(bulletModel.Damager);
        }

        public void Update(float deltaTime)
        {
            MovableService.MoveAlongDirection(deltaTime);
            if (!MovableService.IsInRestrictionBorders())
            {
                Destroyed?.Invoke(this);
            }
        }
    }
}