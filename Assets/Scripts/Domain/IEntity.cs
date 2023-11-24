using System.Collections.Generic;
using Domain.Models;

namespace Domain
{
    public interface IEntity
    {
        IModel Models { get; }
        IEnumerable<ILogic> LogicSet { get; }
    }
}