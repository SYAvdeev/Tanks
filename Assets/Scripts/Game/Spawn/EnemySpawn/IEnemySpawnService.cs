namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnService
    {
        IEnemySpawnModel Model { get; }
        void Update(float deltaTime);
    }
}