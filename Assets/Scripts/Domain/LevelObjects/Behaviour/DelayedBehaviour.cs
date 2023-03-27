namespace Domain.LevelObjects.Behaviour
{
    public abstract class DelayedBehaviour : TickBehaviour
    {
        private float _delay;
        private float _currentDelay;
        
        public float Delay
        {
            set
            {
                _delay = value;
                Reset();
            }
        }

        protected DelayedBehaviour(float delay)
        {
            _delay = delay;
            Reset();
        }
        
        public void Reset()
        {
            _currentDelay = _delay;
        }
        
        protected override void TickInternal(float deltaTime)
        {
            if (_currentDelay > 0f)
            {
                _currentDelay -= deltaTime;
            }
            else
            {
                _currentDelay = _delay;
                Action();
            }
        }

        protected abstract void Action();
    }
}