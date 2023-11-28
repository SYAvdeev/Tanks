using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Models;

namespace Features.DelayedDamager
{
    public class DelayedDamagerViewModel : BaseViewModel
    {
        private readonly DelayedDamageLogic _delayedDamageLogic;

        public DelayedDamagerViewModel(IModel model, DelayedDamageLogic delayedDamageLogic) : base(model)
        {
            _delayedDamageLogic = delayedDamageLogic;
        }

        public void StartDelayedDamageLogic(IDamageableLogic damageableLogic)
        {
            float damage = _model.GetProperty<float>(ModelPropertyName.Damage).Value;
            float delay = _model.GetProperty<float>(ModelPropertyName.Delay).Value;
            
            _delayedDamageLogic.SetParameters(damageableLogic, damage, delay);
            _delayedDamageLogic.SubscribeToTickService(true);
        }

        public void StopDelayedDamageLogic()
        {
            _delayedDamageLogic.SubscribeToTickService(false);
        }
    }
}