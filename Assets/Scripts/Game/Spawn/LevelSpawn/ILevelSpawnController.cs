using System;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Level;

namespace Tanks.Game.Spawn.LevelSpawn
{
    public interface ILevelSpawnController : IDisposable
    {
        UniTask<LevelController> UpdateCurrentLevelControllerTask { get; }
        void Initialize();
    }
}