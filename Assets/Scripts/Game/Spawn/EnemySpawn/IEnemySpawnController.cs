using System;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Enemy;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public interface IEnemySpawnController : IDisposable
    {
        UniTask<IEnemyController> SpawnEnemyControllerTask { get; }
        void Initialize();
    }
}