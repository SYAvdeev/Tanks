using System;

namespace Tanks.Game.Camera
{
    public interface ICameraController : IDisposable
    {
        void Initialize();
    }
}