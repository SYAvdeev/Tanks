using System;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnService : IDisposable
    {
        IEnemySpawnModel Model { get; }
        void Update(float deltaTime);
    }
}