using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public interface ICameraService
    {
        ICameraModel Model { get; }
        MovableService MovableService { get; }
        void Update();
    }
}