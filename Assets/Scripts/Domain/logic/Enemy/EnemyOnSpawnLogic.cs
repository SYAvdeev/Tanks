using Domain.Features;
using Domain.Logic.Damager;
using Domain.Logic.Destroyable;
using Domain.Logic.Transformable;

namespace Domain.Logic.Enemy
{
    public class EnemyOnSpawnLogic : IEnemyOnSpawnLogic
    {
        private readonly ILookAtLogic _lookAtLogic;
        private readonly IMoveLogic _moveLogic;
        private readonly IDelayedDamageLogic _delayedDamageLogic;
        private readonly IDestroyableFeatureLogic _destroyableFeatureLogic;

        public EnemyOnSpawnLogic(
            ILookAtLogic lookAtLogic, 
            IMoveLogic moveLogic, 
            IDelayedDamageLogic delayedDamageLogic,
            IDestroyableFeatureLogic destroyableFeatureLogic)
        {
            _lookAtLogic = lookAtLogic;
            _moveLogic = moveLogic;
            _delayedDamageLogic = delayedDamageLogic;
            _destroyableFeatureLogic = destroyableFeatureLogic;
            
            destroyableFeatureLogic.Destroyed += DestroyableFeatureLogicOnDestroyed;
        }

        private void DestroyableFeatureLogicOnDestroyed(IFeature feature)
        {
            Unsubscribe();
        }

        public void Subscribe()
        {
            _lookAtLogic.Subscribe(true);
            _moveLogic.Subscribe(true);
        }

        public void Unsubscribe()
        {
            _lookAtLogic.Subscribe(false);
            _moveLogic.Subscribe(false);
            _delayedDamageLogic.Subscribe(false);
        }
    }
}