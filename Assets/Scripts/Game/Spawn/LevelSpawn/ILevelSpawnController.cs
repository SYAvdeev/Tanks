using System;
using Cysharp.Threading.Tasks;

namespace Tanks.Game.LevelObjects.Level
{
    public interface ILevelSpawnController : IDisposable
    {
        UniTask<LevelController> UpdateCurrentLevelControllerTask { get; }
        void Initialize();
    }
}