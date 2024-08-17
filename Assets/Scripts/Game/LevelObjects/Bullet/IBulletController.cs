using System;

namespace Tanks.Bullet
{
    public interface IBulletController : IDisposable
    {
        void Initialize();
    }
}