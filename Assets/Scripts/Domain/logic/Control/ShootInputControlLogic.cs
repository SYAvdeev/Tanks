using Domain.Logic.Delayed;
using Domain.Logic.GameSpawn;
using Domain.Services;
using Domain.Services.Input;
using ReactiveTypes;

namespace Domain.Logic.Control
{
    public class ShootInputControlLogic : DelayedActionLogic, IShootInputControlLogic
    {
        private readonly IInputService _inputService;
        private readonly IGameSpawnLogic _gameSpawnLogic;

        private bool _canShoot;
        
        public ShootInputControlLogic(
            ITickService tickService,
            IInputService inputService,
            IReactivePropertyReadonly<float> delay, 
            IReactiveProperty<float> currentDelay,
            IGameSpawnLogic gameSpawnLogic) :
            base(tickService, delay, currentDelay)
        {
            _inputService = inputService;
            _gameSpawnLogic = gameSpawnLogic;
            
            inputService.OnInput += InputServiceOnOnInput;

            _canShoot = true;
        }

        private void InputServiceOnOnInput(InputType inputType)
        {
            if (!_canShoot)
            {
                return;
            }
            
            switch (inputType)
            {
                case InputType.Shoot:
                    _gameSpawnLogic.SpawnOnShoot();
                    _canShoot = false;
                    Subscribe(true);
                    break;
            }
        }

        protected override void Action()
        {
            _canShoot = true;
            Subscribe(false);
        }
    }
}