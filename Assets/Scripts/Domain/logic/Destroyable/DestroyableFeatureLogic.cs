using System;
using Domain.Features;

namespace Domain.Logic.Destroyable
{
    public class DestroyableFeatureLogic : IDestroyableFeatureLogic
    {
        private readonly IFeatureBase _featureBase;

        public event Action<IFeatureBase> Destroyed;

        public DestroyableFeatureLogic(IFeatureBase featureBase)
        {
            _featureBase = featureBase;
        }

        public void Destroy()
        {
            Destroyed?.Invoke(_featureBase);
        }
    }
}