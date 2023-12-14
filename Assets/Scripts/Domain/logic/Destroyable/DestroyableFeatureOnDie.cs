using Domain.Features;
using Domain.Logic.Damageable;
using Domain.Services;

namespace Domain.Logic.Destroyable
{
    public class DestroyableFeatureOnDie : DestroyableFeatureLogic
    {
        private readonly IDamageableLogic _damageableLogic;

        public DestroyableFeatureOnDie(
            IDamageableLogic damageableLogic,
            IFeature feature,
            ISpawnFeatureService spawnFeatureService) : base(feature, spawnFeatureService)
        {
            _damageableLogic = damageableLogic;
            _damageableLogic.Died += Destroy;
        }
    }
}