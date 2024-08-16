namespace Tanks.LevelObjects.Basic
{
    public class SpawnableModel : ISpawnableModel
    {
        public ISpawnableConfig Config { get; }

        public SpawnableModel(ISpawnableConfig config)
        {
            Config = config;
        }
    }
}