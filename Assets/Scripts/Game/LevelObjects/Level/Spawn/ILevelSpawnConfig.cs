using System.Collections.Generic;

namespace Tanks.LevelObjects.Level.Spawn
{
    public interface ILevelSpawnConfig
    {
        ILevelConfig FirstLevelConfig { get; }
        IReadOnlyCollection<ILevelConfig> LevelConfigs { get; }
    }
}