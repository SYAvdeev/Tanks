namespace Tanks.LevelObjects.Basic
{
    public class SpawnableModel
    {
        public ISpawnableConfig Config { get; }

        public SpawnableModel(ISpawnableConfig config)
        {
            Config = config;
        }
    }
}