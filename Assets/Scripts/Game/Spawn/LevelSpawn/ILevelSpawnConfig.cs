using System.Collections.Generic;
using Tanks.Game.LevelObjects.Level;

namespace Tanks.Game.Spawn.LevelSpawn
{
    public interface ILevelSpawnConfig
    {
        ILevelConfig FirstLevelConfig { get; }
        IReadOnlyCollection<ILevelConfig> LevelConfigs { get; }
    }
}