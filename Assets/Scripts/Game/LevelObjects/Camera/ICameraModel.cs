using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.Camera
{
    public interface ICameraModel
    {
        ICameraConfig CameraConfig { get; }
        IMovableModel Movable { get; }
    }
}