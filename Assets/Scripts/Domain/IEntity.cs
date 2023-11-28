using System.Collections.Generic;
using Domain.Models;

namespace Domain
{
    public interface IEntity
    {
        IModel Model { get; }
        IEnumerable<ILogic> LogicSet { get; }
    }
}