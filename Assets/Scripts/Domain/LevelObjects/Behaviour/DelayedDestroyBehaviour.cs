namespace Domain.LevelObjects.Behaviour
{
    public class DelayedDestroyBehaviour : DelayedBehaviour
    {
        private readonly LevelObjectModel _target;
        
        public DelayedDestroyBehaviour(float delay, LevelObjectModel target) : base(delay)
        {
            _target = target;
        }

        protected override void Action()
        {
            _target.Destroy();
        }
    }
}