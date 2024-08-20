using Tanks.Game.LevelObjects.Basic;
using Tanks.Game.LevelObjects.Player;

namespace Tanks.Game.LevelObjects.Camera
{
    public class CameraService : ICameraService
    {
        private readonly IPlayerService _playerService;
        public ICameraModel Model { get; }
        public IMovableService MovableService { get; }

        public CameraService(ICameraModel model, IPlayerService playerService)
        {
            Model = model;
            _playerService = playerService;
            MovableService = new MovableService(model.Movable);
        }

        public void Update()
        {
            MovableService.SetPosition(_playerService.Model.Movable.Position);
            MovableService.ClampPositionToRestrictionBorders();
        }
    }
}