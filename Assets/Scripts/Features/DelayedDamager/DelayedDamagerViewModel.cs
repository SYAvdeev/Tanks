using Domain.Logic;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Logic.Transformable;
using Domain.Models;

namespace Features.DelayedDamager
{
    public class DelayedDamagerViewModel : BaseViewModel
    {
        private readonly IDelayedDamageLogic _delayedDamageLogic;
        private readonly IMoveLogic _moveLogic;

        public DelayedDamagerViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            _delayedDamageLogic = logicCollection.Get<IDelayedDamageLogic>();
            _moveLogic = logicCollection.Get<IMoveLogic>();
        }

        public void StartDelayedDamageLogic(IDamageableLogic damageableLogic)
        {
            _delayedDamageLogic.SetTarget(damageableLogic);
            _delayedDamageLogic.Subscribe(true);
            _moveLogic.Subscribe(false);
        }

        public void StopDelayedDamageLogic()
        {
            _delayedDamageLogic.Subscribe(false);
            _moveLogic.Subscribe(true);
        }
    }
}