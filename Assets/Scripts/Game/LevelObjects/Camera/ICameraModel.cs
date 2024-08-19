using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public interface ICameraModel
    {
        ICameraConfig CameraConfig { get; }
        IMovableModel Movable { get; }
    }
}