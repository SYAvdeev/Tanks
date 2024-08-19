namespace Tanks.Enemy
{
    public interface IEnemyService
    {
        IEnemyModel Model { get; }
        void Update(float deltaTime);
    }
}