using Domain.Features;
using Domain.Logic;

namespace Services.Factory
{
    public interface ILogicFactory
    {
        ILogic CreateLogic(LogicFactoryType logicType, IFeature feature);
    }
}