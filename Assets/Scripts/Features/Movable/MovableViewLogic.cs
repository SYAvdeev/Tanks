using Common.Extensions;
using UnityEngine;

namespace Features.Movable
{
    public class MovableViewLogic : BaseViewLogic<MovableViewModel, MovableViewFacade>
    {
        public MovableViewLogic(MovableViewModel movableViewModel, MovableViewFacade movableViewFacade) :
            base(movableViewModel, movableViewFacade)
        {
            movableViewModel.PositionX.OnValueChanged += PositionXOnOnValueChanged;
            movableViewModel.PositionY.OnValueChanged += PositionYOnOnValueChanged;
            movableViewModel.AngleDegrees.OnValueChanged += DirectionAngleOnOnValueChanged;
        }
        
        private void PositionXOnOnValueChanged(float x)
        {
            _viewFacade.Transform.localPosition = _viewFacade.Transform.localPosition.WithX(x);
        }

        private void PositionYOnOnValueChanged(float y)
        {
            _viewFacade.Transform.localPosition = _viewFacade.Transform.localPosition.WithY(y);
        }

        private void DirectionAngleOnOnValueChanged(float angle)
        {
            _viewFacade.RotationTransform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}