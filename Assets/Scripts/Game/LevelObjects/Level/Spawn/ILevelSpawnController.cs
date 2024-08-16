using System;
using Cysharp.Threading.Tasks;

namespace Tanks.LevelObjects.Level.Spawn
{
    public interface ILevelSpawnController : IDisposable
    {
        UniTask<LevelController> UpdateCurrentLevelControllerTask { get; }
        void Initialize();
    }
}