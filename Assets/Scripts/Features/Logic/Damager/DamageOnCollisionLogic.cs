using Cysharp.Threading.Tasks;
using Domain.Logic.Damager;
using Features.Damageable;
using Features.Damager;
using Services.Factory.ViewModel;

namespace Features.Logic.Damager
{
    public class DamageOnCollisionLogic : IDamageOnCollisionLogic, IInitializableAfterBuildLogic
    {
        private readonly IFeature _damagerFeature;
        private readonly IDamagerLogic _damagerLogic;

        public DamageOnCollisionLogic(IFeature damagerFeature, IDamagerLogic damagerLogic)
        {
            _damagerLogic = damagerLogic;
            _damagerFeature = damagerFeature;
        }

        public UniTask Initialize()
        {
            DamagerPhysics damagerPhysics = 
                _damagerFeature.ViewRoot.GetViewFacade<DamagerViewFacade>(ViewType.Damager).DamagerPhysics;

            damagerPhysics.CollisionWithDamageable += DamagerPhysicsOnCollisionWithDamageable;

            return UniTask.CompletedTask;
        }
        
        private void DamagerPhysicsOnCollisionWithDamageable(DamageablePhysics damageablePhysics)
        {
            _damagerLogic.Damage(damageablePhysics.DamageableLogic);
        }
    }
}