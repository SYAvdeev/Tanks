using Tanks.Game.LevelObjects.Level;
using Tanks.Game.Spawn.LevelSpawn;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraController : ICameraController
    {
        private readonly UnityEngine.Camera _camera;
        private readonly ILevelSpawnModel _levelSpawnModel;
        private readonly ICameraService _cameraService;

        public CameraController(
            UnityEngine.Camera camera, 
            ILevelSpawnModel levelSpawnModel,
            ICameraService cameraService)
        {
            _camera = camera;
            _levelSpawnModel = levelSpawnModel;
            _cameraService = cameraService;
        }

        public void Initialize()
        {
            _levelSpawnModel.CurrentLevelChanged += LevelSpawnModelOnCurrentLevelChanged;
        }

        private void LevelSpawnModelOnCurrentLevelChanged(ILevelModel levelModel)
        {
            float height = _cameraService.Model.CameraConfig.SizeY;
            float width = height * _camera.aspect;

            _camera.orthographicSize = height / 2f;
            
            _cameraService.Model.SetSizeX(width);

            Vector2 minPosition = levelModel.LevelConfig.MinPosition + new Vector2(height / 2f, width / 2f);
            Vector2 maxPosition = levelModel.LevelConfig.MaxPosition - new Vector2(height / 2f, width / 2f);
            _cameraService.MovableService.SetRestrictions(minPosition, maxPosition);
        }

        public void Dispose()
        {
            _levelSpawnModel.CurrentLevelChanged -= LevelSpawnModelOnCurrentLevelChanged;
        }
    }
}