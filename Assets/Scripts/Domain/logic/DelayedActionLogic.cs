namespace Domain.Logic
{
    public abstract class DelayedActionLogic : IDelayedActionLogic
    {
        private readonly float _delay;
        
        public float CurrentDelay { get; protected set; }

        protected DelayedActionLogic(float delay)
        {
            _delay = delay;
            ResetDelay();
        }

        public void ResetDelay()
        {
            CurrentDelay = _delay;
        }

        protected abstract void Action();
        
        public void Tick(float deltaTime)
        {
            if (CurrentDelay > 0f)
            {
                CurrentDelay -= deltaTime;
            }
            else
            {
                CurrentDelay = _delay;
                Action();
            }
        }
    }
}