using Domain.Logic.Subscribable;
using Domain.Services;

namespace Domain.Logic.Tickable
{
    public abstract class TickableLogic : SubscribableLogic, ITickableLogic
    {
        private readonly ITickService _tickService;

        protected TickableLogic(ITickService tickService)
        {
            _tickService = tickService;
        }
        
        public abstract void Tick(float deltaTime);

        protected sealed override void Subscribe()
        {
            _tickService.Tick += Tick;
        }

        protected sealed override void Unsubscribe()
        {
            _tickService.Tick -= Tick;
        }
    }
}