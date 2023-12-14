using Features.Damageable;

namespace Features.Damager
{
    public class DamagerViewLogic : BaseViewLogic<DamagerViewModel, DamagerViewFacade>
    {
        public DamagerViewLogic(DamagerViewModel viewModel, DamagerViewFacade viewFacade) : base(viewModel, viewFacade)
        {
            viewFacade.DamagerPhysics.CollisionWithDamageable += DamagerPhysicsOnCollisionWithDamageable;
        }

        private void DamagerPhysicsOnCollisionWithDamageable(DamageablePhysics damageablePhysics)
        {
            _viewModel.Damage(damageablePhysics.DamageableViewLogic.DamageableViewModel.DamageableLogic);
        }
    }
}