using Domain.Features;
using Domain.Logic.Damageable;
using Domain.Services;

namespace Domain.Logic.Destroyable
{
    public class DestroyableFeatureOnDie : DestroyableFeatureLogic
    {
        private readonly IDamageableLogic _damageableLogic;

        public DestroyableFeatureOnDie(IDamageableLogic damageableLogic, IFeatureBase featureBase) : base(featureBase)
        {
            _damageableLogic = damageableLogic;
            _damageableLogic.Died += Destroy;
        }
    }
}