namespace Domain.LevelObjects.Behaviour
{
    public class DelayedDeactivateBehaviour : DelayedBehaviour
    {
        public DelayedDeactivateBehaviour() : base(0f)
        {
        }

        public DelayedDeactivateBehaviour(float delay) : base(delay)
        {
        }
        
        protected override void Action()
        {
            IsActive = false;
        }
    }
}