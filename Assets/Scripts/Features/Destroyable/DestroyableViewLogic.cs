namespace Features.Destroyable
{
    public class DestroyableViewLogic : BaseViewLogic<DestroyableViewModel, DestroyableViewFacade>
    {
        public DestroyableViewLogic(DestroyableViewModel viewModel, DestroyableViewFacade viewFacade) :
            base(viewModel, viewFacade)
        {
            viewFacade.DestroyableOnCollisionPhysics.Collision += DestroyableOnCollisionPhysicsOnCollision;
        }

        private void DestroyableOnCollisionPhysicsOnCollision()
        {
            _viewModel.Destroy();
        }
    }
}