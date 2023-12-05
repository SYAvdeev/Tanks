using Domain.Logic.Tickable;
using Services;

namespace Domain.Logic.Delayed
{
    public abstract class DelayedActionLogic : TickableLogic, IDelayedActionLogic
    {
        public float Delay;
        public float CurrentDelay { get; protected set; }
        
        protected DelayedActionLogic(ITickService tickService) : base(tickService)
        {
        }

        public void ResetCurrentDelay()
        {
            CurrentDelay = Delay;
        }

        protected abstract void Action();
        
        public override void Tick(float deltaTime)
        {
            if (CurrentDelay > 0f)
            {
                CurrentDelay -= deltaTime;
            }
            else
            {
                CurrentDelay = Delay;
                Action();
            }
        }
    }
}