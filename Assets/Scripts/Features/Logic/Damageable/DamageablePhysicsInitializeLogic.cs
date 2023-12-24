using Cysharp.Threading.Tasks;
using Domain.Logic.Damageable;
using Features.Damageable;
using Services.Factory.ViewModel;

namespace Features.Logic.Damageable
{
    public class DamageablePhysicsInitializeLogic : IDamageablePhysicsInitializeLogic, IInitializableAfterBuildLogic
    {
        private readonly IDamageableLogic _damageableLogic;
        private readonly IFeature _damageableFeature;

        public DamageablePhysicsInitializeLogic(IDamageableLogic damageableLogic, IFeature damageableFeature)
        {
            _damageableLogic = damageableLogic;
            _damageableFeature = damageableFeature;
        }

        public UniTask Initialize()
        {
            DamageablePhysics damageablePhysics = 
                _damageableFeature.ViewRoot.GetViewFacade<DamageableViewFacade>(ViewType.Damageable).DamageablePhysics;
            damageablePhysics.Initialize(_damageableLogic);
            return UniTask.CompletedTask;
        }
    }
}