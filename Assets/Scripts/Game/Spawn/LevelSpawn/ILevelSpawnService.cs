namespace Tanks.Game.LevelObjects.Level
{
    public interface ILevelSpawnService
    {
        ILevelSpawnModel LevelSpawnModel { get; }
        void Initialize();
    }
}