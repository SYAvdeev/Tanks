using Domain.Logic.Damageable;
using Domain.Logic.Delayed;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Damager
{
    public class DelayedDamageLogic : DelayedActionLogic, IDelayedDamageLogic
    {
        private readonly IDamagerLogic _damagerLogic;
        
        private IDamageableLogic _target;

        public DelayedDamageLogic(
            ITickService tickService,
            IReactivePropertyReadonly<float> delay,
            IReactiveProperty<float> currentDelay,
            IDamagerLogic damagerLogic) : base(tickService, delay, currentDelay)
        {
            _damagerLogic = damagerLogic;
        }

        public void SetTarget(IDamageableLogic target)
        {
            _target = target;
        }

        protected override void Action()
        {
            _damagerLogic.Damage(_target);
        }
    }
}