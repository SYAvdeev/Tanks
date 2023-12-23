using Domain.Logic.Destroyable;
using Features.Destroyable;
using Services.Factory.ViewModel;

namespace Features.Logic.Destroyable
{
    public class DestroyOnCollisionLogic : IDestroyOnCollisionLogic, IInitializableAfterBuildLogic
    {
        private readonly IDestroyableFeatureLogic _destroyableFeatureLogic;
        private readonly IFeature _destroyableFeature;

        public DestroyOnCollisionLogic(
            IDestroyableFeatureLogic destroyableFeatureLogic,
            IFeature destroyableFeature)
        {
            _destroyableFeatureLogic = destroyableFeatureLogic;
            _destroyableFeature = destroyableFeature;
        }
        
        public void Initialize()
        {
            DestroyableOnCollisionPhysics destroyableOnCollisionPhysics = 
                _destroyableFeature.ViewRoot.GetViewFacade<DestroyableViewFacade>(ViewType.Destroyable).DestroyableOnCollisionPhysics;

            destroyableOnCollisionPhysics.Collision += DestroyableOnCollisionPhysicsOnCollision;
        }

        private void DestroyableOnCollisionPhysicsOnCollision()
        {
            _destroyableFeatureLogic.Destroy();
        }
    }
}