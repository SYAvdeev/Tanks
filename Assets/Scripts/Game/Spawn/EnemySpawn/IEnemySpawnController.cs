using System;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnController : IDisposable
    {
        void Initialize();
    }
}