using System;

namespace Tanks.Game.LevelObjects.Enemy
{
    public interface IEnemyController : IDisposable
    {
        void Initialize();
    }
}