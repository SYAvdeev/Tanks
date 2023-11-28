using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Models;

namespace Features.Damager
{
    public class DamagerViewModel : BaseViewModel
    {
        private readonly IDamagerLogic _damagerLogic;

        public DamagerViewModel(IModel model, IDamagerLogic damagerLogic) : base(model)
        {
            _damagerLogic = damagerLogic;
        }

        public virtual void Damage(IDamageableLogic damageableLogic)
        {
            float damage = _model.GetProperty<float>(ModelPropertyName.Damage).Value;
            
            _damagerLogic.Damage(damage, damageableLogic);
        }
    }
}