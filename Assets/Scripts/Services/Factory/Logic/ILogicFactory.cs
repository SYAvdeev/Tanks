using Domain.Logic;
using Features;

namespace Services.Factory.Logic
{
    public interface ILogicFactory
    {
        ILogic CreateLogic(LogicFactoryType logicType, IFeature feature);
    }
}