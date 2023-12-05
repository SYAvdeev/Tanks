using Domain.Logic.Tickable;

namespace Domain.Logic.Delayed
{
    public interface IDelayedActionLogic : ITickableLogic
    {
        float CurrentDelay { get; }
        void ResetCurrentDelay();
    }
}