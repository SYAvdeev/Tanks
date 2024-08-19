using System.Collections.Generic;

namespace Tanks.Game.LevelObjects.Level
{
    public interface ILevelSpawnConfig
    {
        ILevelConfig FirstLevelConfig { get; }
        IReadOnlyCollection<ILevelConfig> LevelConfigs { get; }
    }
}