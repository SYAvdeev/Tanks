using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Bullet
{
    public interface IBulletService
    {
        IBulletModel BulletModel { get; }
        IMovableService MovableService { get; }
        IDamagerService DamagerService { get; }
        event Action<IBulletService> Destroyed;
        void Update(float deltaTime);
    }
}