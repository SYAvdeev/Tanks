using System;
using Domain.Features;
using Domain.Logic.Startable;

namespace Domain.Logic.GameSpawn
{
    public interface IGameSpawnLogic : IStartableLogic
    {
        event Action<string> SpawnRandomEnemyEvent;
        event Action<string> SpawnOnShootEvent;
        void SpawnOnShoot();
        void InitializeRandomEnemy(IFeatureBase enemyFeature);
        void InitializeBullet(IFeatureBase bulletFeature);
    }
}