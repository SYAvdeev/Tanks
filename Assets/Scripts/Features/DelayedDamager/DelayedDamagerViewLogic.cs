using Features.Damageable;

namespace Features.DelayedDamager
{
    public class DelayedDamagerViewLogic : BaseViewLogic<DelayedDamagerViewModel, DelayedDamagerViewFacade>
    {
        public DelayedDamagerViewLogic(DelayedDamagerViewModel viewModel, DelayedDamagerViewFacade viewFacade) : 
            base(viewModel, viewFacade)
        {
            viewFacade.DelayedDamagerPhysics.CollisionEnterWithDamageable += DelayedDamagerPhysicsOnCollisionEnterWithDamageable;
            viewFacade.DelayedDamagerPhysics.CollisionExitWithDamageable += DelayedDamagerPhysicsOnCollisionExitWithDamageable;
        }
        
        private void DelayedDamagerPhysicsOnCollisionEnterWithDamageable(DamageablePhysics damageablePhysics)
        {
            _viewModel.StartDelayedDamageLogic(damageablePhysics.DamageableViewLogic.DamageableViewModel.DamageableLogic);
        }

        private void DelayedDamagerPhysicsOnCollisionExitWithDamageable()
        {
            _viewModel.StopDelayedDamageLogic();
        }
    }
}