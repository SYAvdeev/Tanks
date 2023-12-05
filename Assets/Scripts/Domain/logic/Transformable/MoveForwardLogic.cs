using System;
using Domain.Logic.Tickable;
using ReactiveTypes;
using Services;

namespace Domain.Logic.Transformable
{
    public class MoveForwardLogic : TickableLogic, IMoveLogic
    {
        private readonly IReactiveProperty<float> _positionXProperty;
        private readonly IReactiveProperty<float> _positionYProperty;
        private readonly IReactiveProperty<float> _directionAngleProperty;
        
        private readonly float _speed;

        private readonly IMoveRestrictionLogic _moveRestrictionLogic;

        public MoveForwardLogic(
            ITickService tickService,
            IReactiveProperty<float> positionXProperty,
            IReactiveProperty<float> positionYProperty,
            IReactiveProperty<float> directionAngleProperty,
            float speed) : base(tickService)
        {
            _positionXProperty = positionXProperty;
            _positionYProperty = positionYProperty;
            _directionAngleProperty = directionAngleProperty;
            _speed = speed;
        }

        public MoveForwardLogic(
            ITickService tickService,
            IReactiveProperty<float> positionXProperty,
            IReactiveProperty<float> positionYProperty,
            IReactiveProperty<float> directionAngleProperty,
            float speed,
            IMoveRestrictionLogic moveRestrictionLogic) : 
            this(tickService, positionXProperty, positionYProperty, directionAngleProperty, speed)
        {
            _positionXProperty = positionXProperty;
            _positionYProperty = positionYProperty;
            _directionAngleProperty = directionAngleProperty;
            _speed = speed;
            _moveRestrictionLogic = moveRestrictionLogic;
        }

        public override void Tick(float deltaTime)
        {
            float angle = _directionAngleProperty.Value;

            float x = _positionXProperty.Value + (float)(_speed * Math.Sin(angle)) * deltaTime;
            float y = _positionYProperty.Value + (float)(_speed * Math.Cos(angle)) * deltaTime;

            _moveRestrictionLogic?.Restrict(ref x, ref y);

            _positionXProperty.Value = x;
            _positionYProperty.Value = y;
        }
    }
}