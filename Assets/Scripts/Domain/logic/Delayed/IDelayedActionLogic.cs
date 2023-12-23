using Domain.Logic.Tickable;

namespace Domain.Logic.Delayed
{
    public interface IDelayedActionLogic : ITickableLogic
    {
        void ResetCurrentDelay();
    }
}