using Domain.Logic.Subscribable;
using Domain.Services;

namespace Domain.Logic.Startable
{
    public abstract class StartableLogic : SubscribableLogic, IStartableLogic
    {
        private readonly IStartService _startService;

        protected StartableLogic(IStartService startService)
        {
            _startService = startService;
        }

        public abstract void Start();

        protected override void Subscribe()
        {
            _startService.Start += Start;
        }

        protected override void Unsubscribe()
        {
            _startService.Start -= Start;
        }
    }
}