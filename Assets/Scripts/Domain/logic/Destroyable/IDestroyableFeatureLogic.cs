using System;
using Domain.Features;

namespace Domain.Logic.Destroyable
{
    public interface IDestroyableFeatureLogic : ILogic
    {
        event Action<IFeature> Destroyed;
        void Destroy();
    }
}