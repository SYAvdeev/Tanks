using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Enemy
{
    public interface IEnemyService
    {
        IEnemyModel Model { get; }
        IMovableService MovableService { get; }
        IDamageableService DamageableService { get; }
        void Update(float deltaTime);
    }
}