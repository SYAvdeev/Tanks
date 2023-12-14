using Domain.Features;
using Domain.Logic;
using Services.Factory.Logic;

namespace Services.Factory
{
    public interface ILogicFactory
    {
        ILogic CreateLogic(LogicFactoryType logicType, IFeature feature);
    }
}