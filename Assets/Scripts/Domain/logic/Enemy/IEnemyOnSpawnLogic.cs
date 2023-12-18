namespace Domain.Logic.Enemy
{
    public interface IEnemyOnSpawnLogic : ILogic
    {
        void Subscribe();
        void Unsubscribe();
    }
}