namespace Domain.Logic
{
    public interface ITickableLogic
    {
        void Tick(float deltaTime);
    }

    public interface IMoveLogic : ITickableLogic { }
    
    public interface IRotateLogic : ITickableLogic { }

    public interface IDelayedActionLogic : ITickableLogic
    {
        float CurrentDelay { get; }
        void ResetDelay();
    }
}