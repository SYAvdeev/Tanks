using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Level
{
    public interface ILevelModel
    {
        ILevelConfig LevelConfig { get; }
        ISpawnableModel Spawnable { get; }
    }
}