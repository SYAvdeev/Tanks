using Domain.Logic;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Models;

namespace Features.DelayedDamager
{
    public class DelayedDamagerViewModel : BaseViewModel
    {
        private readonly IDelayedDamageLogic _delayedDamageLogic;

        public DelayedDamagerViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            _delayedDamageLogic = logicCollection.Get<IDelayedDamageLogic>();
        }

        public void StartDelayedDamageLogic(IDamageableLogic damageableLogic)
        {
            _delayedDamageLogic.SetTarget(damageableLogic);
            _delayedDamageLogic.Subscribe(true);
        }

        public void StopDelayedDamageLogic()
        {
            _delayedDamageLogic.Subscribe(false);
        }
    }
}