using System;

namespace Tanks.Enemy
{
    public interface IEnemyController : IDisposable
    {
        void Initialize();
    }
}