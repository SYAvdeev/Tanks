using Domain.Logic.Startable;

namespace Features.Logic.GameSpawn
{
    public interface IGameSpawnLogic : IStartableLogic
    {
        void SpawnOnShoot();
        void SpawnRandomEnemy();
    }
}