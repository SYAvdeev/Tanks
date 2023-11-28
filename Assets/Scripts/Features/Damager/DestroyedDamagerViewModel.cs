using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Models;

namespace Features.Damager
{
    public class DestroyedDamagerViewModel : DamagerViewModel
    {
        public DestroyedDamagerViewModel(IModel model, IDamagerLogic damagerLogic) : base(model, damagerLogic)
        {
        }

        public override void Damage(IDamageableLogic damageableLogic)
        {
            base.Damage(damageableLogic);
        }
    }
}