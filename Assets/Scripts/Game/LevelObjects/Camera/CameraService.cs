using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraService : ICameraService
    {
        private readonly ICameraModel _cameraModel;
        
        public MovableService MovableService { get; }

        public CameraService(ICameraModel cameraModel, MovableService movableService)
        {
            _cameraModel = cameraModel;
            MovableService = movableService;
        }
    }
}