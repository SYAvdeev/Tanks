using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraService : ICameraService
    {
        public ICameraModel Model { get; }

        public MovableService MovableService { get; }

        public CameraService(ICameraModel model, MovableService movableService)
        {
            Model = model;
            MovableService = movableService;
        }
    }
}