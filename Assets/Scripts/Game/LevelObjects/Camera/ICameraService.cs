using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public interface ICameraService
    {
        ICameraModel Model { get; }
        IMovableService MovableService { get; }
        void Update();
    }
}