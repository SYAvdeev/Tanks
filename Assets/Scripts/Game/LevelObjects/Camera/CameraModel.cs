using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraModel : ICameraModel
    {
        public ICameraConfig CameraConfig { get; }
        public IMovableModel Movable { get; }

        public CameraModel(ICameraConfig cameraConfig)
        {
            CameraConfig = cameraConfig;
            Movable = new MovableModel(cameraConfig.MovableConfig, new MovableData());
        }
    }
}