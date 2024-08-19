using System;

namespace Tanks.Game.LevelObjects.Bullet
{
    public interface IBulletController : IDisposable
    {
        IBulletService BulletService { get; }
        void Initialize();
    }
}