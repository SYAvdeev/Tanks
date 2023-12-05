using Domain.Logic.Damageable;
using Domain.Logic.Delayed;
using Domain.Logic.Tickable;
using Services;

namespace Domain.Logic.Damager
{
    public interface IDelayedDamageLogic : IDelayedActionLogic
    {
        void SetParameters(IDamageableLogic target, float damage, float delay);
    }

    public class DelayedDamageLogic : DelayedActionLogic, IDelayedDamageLogic
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