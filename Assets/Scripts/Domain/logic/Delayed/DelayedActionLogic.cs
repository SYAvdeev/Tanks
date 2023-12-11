using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Delayed
{
    public abstract class DelayedActionLogic : TickableLogic, IDelayedActionLogic
    {
        protected IReactivePropertyReadonly<float> Delay { get; }
        protected IReactiveProperty<float> CurrentDelay { get; }
        
        protected DelayedActionLogic(
            ITickService tickService,
            IReactivePropertyReadonly<float> delay,
            IReactiveProperty<float> currentDelay) : base(tickService)
        {
            Delay = delay;
            CurrentDelay = currentDelay;
        }

        public void ResetCurrentDelay()
        {
            CurrentDelay.Value = Delay.Value;
        }

        protected abstract void Action();
        
        public override void Tick(float deltaTime)
        {
            if (CurrentDelay.Value > 0f)
            {
                CurrentDelay.Value -= deltaTime;
            }
            else
            {
                CurrentDelay.Value = Delay.Value;
                Action();
            }
        }
    }
}