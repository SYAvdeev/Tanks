using System.Collections.Generic;
using Domain.Features;
using Domain.Logic.Tickable;

namespace Domain.Logic.Destroyable
{
    public class DestroyableTickableUnsubscribeLogic : IDestroyableTickableUnsubscribeLogic
    {
        private readonly IEnumerable<ITickableLogic> _tickableLogics;
        private readonly IDestroyableFeatureLogic _destroyableFeatureLogic;

        public DestroyableTickableUnsubscribeLogic(
            IEnumerable<ITickableLogic> tickableLogics,
            IDestroyableFeatureLogic destroyableFeatureLogic)
        {
            _tickableLogics = tickableLogics;
            _destroyableFeatureLogic = destroyableFeatureLogic;
            destroyableFeatureLogic.Destroyed += DestroyableFeatureLogicOnDestroyed;
        }

        private void DestroyableFeatureLogicOnDestroyed(IFeatureBase featureBase)
        {
            Unsubscribe();
        }

        public void Unsubscribe()
        {
            foreach (ITickableLogic tickableLogic in _tickableLogics)
            {
                tickableLogic.Subscribe(false);
            }
        }
    }
}