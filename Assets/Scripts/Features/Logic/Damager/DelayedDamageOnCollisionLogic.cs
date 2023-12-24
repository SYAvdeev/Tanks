using Cysharp.Threading.Tasks;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Logic.Transformable;
using Features.Damageable;
using Features.DelayedDamager;
using Services.Factory.ViewModel;

namespace Features.Logic.Damager
{
    public class DelayedDamageOnCollisionLogic : IDelayedDamageOnCollisionLogic, IInitializableAfterBuildLogic
    {
        private readonly IDelayedDamageLogic _delayedDamageLogic;
        private readonly IMoveLogic _moveLogic;
        private readonly IFeature _delayedDamagerFeature;

        public DelayedDamageOnCollisionLogic(
            IDelayedDamageLogic delayedDamageLogic,
            IMoveLogic moveLogic,
            IFeature delayedDamagerFeature)
        {
            _delayedDamageLogic = delayedDamageLogic;
            _moveLogic = moveLogic;
            _delayedDamagerFeature = delayedDamagerFeature;
        }

        public UniTask Initialize()
        {
            DelayedDamagerPhysics delayedDamagerPhysics = 
                _delayedDamagerFeature.ViewRoot.GetViewFacade<DelayedDamagerViewFacade>(ViewType.DelayedDamager).DelayedDamagerPhysics;
            
            delayedDamagerPhysics.CollisionEnterWithDamageable += DelayedDamagerPhysicsOnCollisionEnterWithDamageable;
            delayedDamagerPhysics.CollisionExitWithDamageable += DelayedDamagerPhysicsOnCollisionExitWithDamageable;
            
            return UniTask.CompletedTask;
        }

        private void DelayedDamagerPhysicsOnCollisionEnterWithDamageable(DamageablePhysics damageablePhysics)
        {
            IDamageableLogic damageableLogic = damageablePhysics.DamageableLogic;
            _delayedDamageLogic.SetTarget(damageableLogic);
            _delayedDamageLogic.Subscribe(true);
            _moveLogic.Subscribe(false);
        }
        
        private void DelayedDamagerPhysicsOnCollisionExitWithDamageable()
        {
            _delayedDamageLogic.Subscribe(false);
            _moveLogic.Subscribe(true);
        }
    }
}