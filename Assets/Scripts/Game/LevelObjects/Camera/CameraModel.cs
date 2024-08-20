using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraModel : ICameraModel
    {
        public float SizeX { get; private set; }
        public ICameraConfig CameraConfig { get; }
        public IMovableModel Movable { get; }
        void ICameraModel.SetSizeX(float sizeX)
        {
            SizeX = sizeX;
        }

        public CameraModel(ICameraConfig cameraConfig)
        {
            CameraConfig = cameraConfig;
            Movable = new MovableModel(cameraConfig.MovableConfig, new MovableData());
        }
    }
}