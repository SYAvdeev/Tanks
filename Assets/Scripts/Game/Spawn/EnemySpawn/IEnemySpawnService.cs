namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnService
    {
        IEnemySpawnModel Model { get; }
        void SpawnRandomEnemy();
        void Update(float deltaTime);
    }
}