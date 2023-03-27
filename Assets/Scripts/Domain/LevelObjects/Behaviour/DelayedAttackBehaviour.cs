namespace Domain.LevelObjects.Behaviour
{
    public class DelayedAttackBehaviour : DelayedBehaviour
    {
        private float _damage;
        private readonly CharacterModel _target;

        public DelayedAttackBehaviour(float damage, float delay, CharacterModel target) : base(delay)
        {
            _damage = damage;
            _target = target;
        }

        public void SetParameters(float damage, float delay)
        {
            _damage = damage;
            Delay = delay;
        }

        protected override void Action()
        {
            _target.AddDamage(_damage);
        }
    }
}