using System;
using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class MoveForwardLogic : TickableLogic, IMoveLogic
    {
        private readonly IReactiveProperty<float> _positionXProperty;
        private readonly IReactiveProperty<float> _positionYProperty;
        private readonly IReactiveProperty<float> _directionAngleProperty;
        private readonly IReactiveProperty<float> _speedProperty;

        private readonly IMoveRestrictionLogic _moveRestrictionLogic;

        public MoveForwardLogic(
            ITickService tickService,
            IReactiveProperty<float> positionXProperty,
            IReactiveProperty<float> positionYProperty,
            IReactiveProperty<float> directionAngleProperty,
            IReactiveProperty<float> speedProperty,
            IMoveRestrictionLogic moveRestrictionLogic)
            : base(tickService)
        {
            _positionXProperty = positionXProperty;
            _positionYProperty = positionYProperty;
            _directionAngleProperty = directionAngleProperty;
            _speedProperty = speedProperty;
            _moveRestrictionLogic = moveRestrictionLogic;
        }

        public override void Tick(float deltaTime)
        {
            float angle = _directionAngleProperty.Value;

            float x = _positionXProperty.Value + (float)(_speedProperty.Value * Math.Sin(angle)) * deltaTime;
            float y = _positionYProperty.Value + (float)(_speedProperty.Value * Math.Cos(angle)) * deltaTime;

            _moveRestrictionLogic?.Restrict(ref x, ref y);

            _positionXProperty.Value = x;
            _positionYProperty.Value = y;
        }
    }
}