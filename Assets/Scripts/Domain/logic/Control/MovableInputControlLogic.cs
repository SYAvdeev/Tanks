using Domain.Logic.Transformable;
using Domain.Services.Input;

namespace Domain.Logic.Control
{
    public class MovableInputControlLogic : IMovableInputControlLogic
    {
        private readonly IMoveLogic _moveLogic;
        private readonly IRotateLogic _rotateLogic;
        private readonly IInputService _inputService;

        public MovableInputControlLogic(
            IMoveLogic moveLogic,
            IRotateLogic rotateLogic,
            IInputService inputService)
        {
            _moveLogic = moveLogic;
            _rotateLogic = rotateLogic;
            _inputService = inputService;
            
            inputService.OnInput += InputServiceOnOnInput;
        }

        private void InputServiceOnOnInput(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.StartMove:
                    _moveLogic.Subscribe(true);
                    break;
                case InputType.StopMove:
                    _moveLogic.Subscribe(false);
                    break;
                case InputType.StartTurnLeft:
                    _rotateLogic.IsClockwise = false;
                    _rotateLogic.Subscribe(true);
                    break;
                case InputType.StopTurnLeft:
                    _rotateLogic.Subscribe(false);
                    break;
                case InputType.StartTurnRight:
                    _rotateLogic.IsClockwise = true;
                    _rotateLogic.Subscribe(false);
                    break;
                case InputType.StopTurnRight:
                    _rotateLogic.Subscribe(false);
                    break;
            }
        }
    }
}