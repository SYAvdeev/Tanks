using Tanks.Game.LevelObjects.Level;
using Tanks.Game.Spawn.LevelSpawn;
using Tanks.Utility;
using Tanks.Utility.Extensions;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraController : ICameraController
    {
        private readonly UnityEngine.Camera _camera;
        private readonly ILevelSpawnModel _levelSpawnModel;
        private readonly ICameraService _cameraService;
        
        private readonly UniTaskRestartable _updateTask;

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
            _cameraService.Model.Movable.PositionUpdated += MovableOnPositionUpdated;
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _camera.transform.localPosition = _camera.transform.localPosition.WithX(position.x).WithY(position.y);
        }

        private void LevelSpawnModelOnCurrentLevelChanged(ILevelModel levelModel)
        {
            float height = _cameraService.Model.CameraConfig.SizeY;
            float width = height * _camera.aspect;

            _camera.orthographicSize = height / 2f;
            
            _cameraService.Model.SetSizeX(width);

            Vector2 minPosition = levelModel.LevelConfig.MinPosition + new Vector2(width / 2f, height / 2f);
            Vector2 maxPosition = levelModel.LevelConfig.MaxPosition - new Vector2(width / 2f, height / 2f);
            _cameraService.MovableService.SetRestrictions(minPosition, maxPosition);
        }

        public void Dispose()
        {
            _levelSpawnModel.CurrentLevelChanged -= LevelSpawnModelOnCurrentLevelChanged;
            _cameraService.Model.Movable.PositionUpdated -= MovableOnPositionUpdated;
        }
    }
}