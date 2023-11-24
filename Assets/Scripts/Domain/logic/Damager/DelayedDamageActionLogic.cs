using Domain.Logic.Damageable;

namespace Domain.Logic.Damager
{
    public class DelayedDamageActionLogic : DelayedActionLogic
    {
        private readonly float _damage;
        private readonly IDamageableLogic _target;

        public DelayedDamageActionLogic(float damage, float delay, IDamageableLogic target) : base(delay)
        {
            _damage = damage;
            _target = target;
        }

        protected override void Action()
        {
            _target.GetDamage(_damage);
        }
    }
}