using Domain.Logic.Subscribable;
using Domain.Logic.Tickable;

namespace Domain.Logic.Destroyable
{
    public interface IDestroyableFeatureOutOfLevelBoundsLogic : ITickableLogic, IDestroyableFeatureLogic
    {
        
    }
}