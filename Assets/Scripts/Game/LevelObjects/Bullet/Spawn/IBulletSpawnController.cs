using System;

namespace Tanks.Bullet
{
    public interface IBulletSpawnController : IDisposable
    {
        void Initialize();
    }
}