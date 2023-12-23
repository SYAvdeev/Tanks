using Domain.Logic;
using Domain.Models;

namespace Domain.Features
{
    public interface IFeatureBase
    {
        string ID { get; }
        IModel Model { get; }
        ILogicCollection LogicCollection { get; }
    }
}