using Tanks.LevelObjects.Basic;

namespace Tanks.LevelObjects.Level
{
    public interface ILevelModel
    {
        ILevelConfig LevelConfig { get; }
        ISpawnableModel Spawnable { get; }
    }
}