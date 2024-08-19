using System;

namespace Tanks.Bullet
{
    public interface IBulletController : IDisposable
    {
        IBulletService BulletService { get; }
        void Initialize();
    }
}