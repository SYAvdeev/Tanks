using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Enemy
{
    public interface IEnemyService : IDisposable
    {
        event Action<IEnemyService> Died;
        IEnemyModel Model { get; }
        IMovableService MovableService { get; }
        IDamageableService DamageableService { get; }
        void Update(float deltaTime);
    }
}