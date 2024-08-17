namespace Tanks.Game.LevelObjects.Level
{
    public class LevelSpawnService : ILevelSpawnService
    {
        public ILevelSpawnModel LevelSpawnModel { get; }

        public LevelSpawnService(ILevelSpawnModel levelSpawnModel)
        {
            LevelSpawnModel = levelSpawnModel;
        }

        public void Initialize()
        {
            var currentLevelConfig = LevelSpawnModel.IsCurrentLevelIDEmpty
                ? LevelSpawnModel.Config.FirstLevelConfig
                : LevelSpawnModel.CurrentLevelConfig;

            SpawnLevel(currentLevelConfig);
        }

        private void SpawnLevel(ILevelConfig levelConfig)
        {
            if (!LevelSpawnModel.LevelsPool.TryGetValue(levelConfig.SpawnableConfig.ID, out var levelModel))
            {
                levelModel = new LevelModel(levelConfig);
            }
            
            LevelSpawnModel.SetCurrentLevel(levelModel);
        }
    }
}