using Domain.Logic.Startable;

namespace Domain.Logic.GameSpawn
{
    public interface IGameSpawnLogic : IStartableLogic
    {
        void SpawnOnShoot();
        void SpawnOnDied();
    }
}