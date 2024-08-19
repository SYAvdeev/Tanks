namespace Tanks.Game.Spawn.LevelSpawn
{
    public interface ILevelSpawnService
    {
        ILevelSpawnModel LevelSpawnModel { get; }
        void Initialize();
    }
}