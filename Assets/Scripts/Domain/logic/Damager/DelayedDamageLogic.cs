using Domain.Logic.Damageable;
using Services;

namespace Domain.Logic.Damager
{
    public class DelayedDamageLogic : DelayedActionLogic
    {
        private readonly IDamagerLogic _damagerLogic;
        
        private float _damage;
        private IDamageableLogic _target;

        public DelayedDamageLogic(IDamagerLogic damagerLogic, ITickService tickService) : base(tickService)
        {
            _damagerLogic = damagerLogic;
        }

        public void SetParameters(IDamageableLogic target, float damage, float delay)
        {
            _damage = damage;
            _target = target;
            Delay = delay;
        }

        protected override void Action()
        {
            _damagerLogic.Damage(_damage, _target);
        }
    }
}