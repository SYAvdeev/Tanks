using Domain.Logic.GameSpawn;
using Domain.Services.Input;

namespace Domain.Logic.Control
{
    public class ShootInputControlLogic : IShootInputControlLogic
    {
        private readonly IInputService _inputService;
        private readonly IGameSpawnLogic _gameSpawnLogic;

        public ShootInputControlLogic(IInputService inputService, IGameSpawnLogic gameSpawnLogic)
        {
            _inputService = inputService;
            _gameSpawnLogic = gameSpawnLogic;
            
            inputService.OnInput += InputServiceOnOnInput;
        }

        private void InputServiceOnOnInput(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.Shoot:
                    _gameSpawnLogic.SpawnOnShoot();
                    break;
            }
        }
    }
}