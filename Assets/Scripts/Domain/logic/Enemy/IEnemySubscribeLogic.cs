namespace Domain.Logic.Enemy
{
    public interface IEnemySubscribeLogic : ILogic
    {
        void Subscribe();
        void Unsubscribe();
    }
}