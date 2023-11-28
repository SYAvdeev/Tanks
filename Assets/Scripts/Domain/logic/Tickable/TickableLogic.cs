using Services;

namespace Domain.Logic.Tickable
{
    public abstract class TickableLogic : ITickableLogic
    {
        private readonly ITickService _tickService;
        
        private bool _isSubscribed;

        protected TickableLogic(ITickService tickService)
        {
            _tickService = tickService;
        }

        public void SubscribeToTickService(bool isSubscribe)
        {
            if (isSubscribe == _isSubscribed)
            {
                return;
            }
            
            if (isSubscribe)
            {
                _tickService.Tick += Tick;
            }
            else
            {
                _tickService.Tick -= Tick;
            }

            _isSubscribed = isSubscribe;
        }

        public abstract void Tick(float deltaTime);
    }
}