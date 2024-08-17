using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.Camera
{
    public interface ICameraConfig
    {
        IMovableConfig MovableConfig { get; }
        float SizeX { get; }
        float SizeY { get; }
    }
}