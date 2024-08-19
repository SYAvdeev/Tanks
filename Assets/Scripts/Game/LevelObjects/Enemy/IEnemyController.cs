using System;

namespace Tanks.Game.LevelObjects.Enemy
{
    public interface IEnemyController : IDisposable
    {
        IEnemyService EnemyService { get; }
        void Initialize();
    }
}