using Domain.Logic.Subscribable;

namespace Domain.Logic.Startable
{
    public interface IStartableLogic : ISubscribableLogic
    {
        void Start();
    }
}