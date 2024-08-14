using System;

namespace Tanks.LevelObjects.Level.Spawn
{
    public interface ILevelSpawnController : IDisposable
    {
        void Initialize();
    }
}