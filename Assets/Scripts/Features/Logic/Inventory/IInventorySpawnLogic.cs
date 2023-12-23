using System;
using System.Collections.Generic;
using Domain.Logic;

namespace Features.Logic.Inventory
{
    public interface IInventorySpawnLogic : ILogic
    {
        event Action<IReadOnlyList<IFeature>> ItemsSpawned;
    }
}