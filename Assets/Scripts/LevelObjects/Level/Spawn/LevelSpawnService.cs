namespace Tanks.LevelObjects.Level.Spawn
{
    public class LevelSpawnService : ILevelSpawnService
    {
        private readonly ILevelSpawnModel _levelSpawnModel;

        public void Initialize()
        {
            var currentLevelConfig = _levelSpawnModel.IsCurrentLevelIDEmpty
                ? _levelSpawnModel.Config.FirstLevelConfig
                : _levelSpawnModel.CurrentLevelConfig;

            SpawnLevel(currentLevelConfig);
        }

        private void SpawnLevel(ILevelConfig levelConfig)
        {
            if (!_levelSpawnModel.LevelsPool.TryGetValue(levelConfig.SpawnableConfig.ID, out var levelModel))
            {
                levelModel = new LevelModel(levelConfig);
            }
            
            _levelSpawnModel.SetCurrentLevel(levelModel);
        }
    }
}