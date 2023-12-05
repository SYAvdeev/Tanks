using Domain.Logic.Subscribable;

namespace Domain.Logic.Tickable
{
    public interface ITickableLogic : ISubscribableLogic
    {
        void Tick(float deltaTime);
    }
}