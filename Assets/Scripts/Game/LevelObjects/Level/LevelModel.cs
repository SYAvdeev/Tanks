using Tanks.LevelObjects.Basic;

namespace Tanks.LevelObjects.Level
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