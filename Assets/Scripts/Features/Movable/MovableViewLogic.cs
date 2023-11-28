using Common.Extensions;
using UnityEngine;

namespace Features.Movable
{
    public class MovableViewLogic
    {
        private readonly MovableViewFacade _movableViewFacade;
        private readonly MovableViewModel _movableViewModel;

        public MovableViewLogic(MovableViewFacade movableViewFacade, MovableViewModel movableViewModel)
        {
            _movableViewFacade = movableViewFacade;
            _movableViewModel = movableViewModel;
            
            movableViewModel.PositionX.OnValueChanged += PositionXOnOnValueChanged;
            movableViewModel.PositionY.OnValueChanged += PositionYOnOnValueChanged;
            movableViewModel.AngleDegrees.OnValueChanged += DirectionAngleOnOnValueChanged;
        }
        
        private void PositionXOnOnValueChanged(float x)
        {
            _movableViewFacade.Transform.localPosition = _movableViewFacade.Transform.localPosition.WithX(x);
        }

        private void PositionYOnOnValueChanged(float y)
        {
            _movableViewFacade.Transform.localPosition = _movableViewFacade.Transform.localPosition.WithY(y);
        }

        private void DirectionAngleOnOnValueChanged(float angle)
        {
            _movableViewFacade.Transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}