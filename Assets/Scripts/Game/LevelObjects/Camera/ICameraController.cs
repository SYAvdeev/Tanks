using System;

namespace Tanks.Game.LevelObjects.Camera
{
    public interface ICameraController : IDisposable
    {
        void Initialize();
    }
}