using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Level
{
    public class LevelModel : ILevelModel
    {
        public ILevelConfig LevelConfig { get; }
        public ISpawnableModel Spawnable { get; }

        public LevelModel(ILevelConfig levelConfig)
        {
            LevelConfig = levelConfig;
            Spawnable = new SpawnableModel(LevelConfig.SpawnableConfig);
        }
    }
}