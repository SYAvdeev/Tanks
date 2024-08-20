using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public interface ICameraModel
    {
        float SizeX { get; }
        ICameraConfig CameraConfig { get; }
        IMovableModel Movable { get; }
        internal void SetSizeX(float sizeX);
    }
}