using System;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class MoveLogic : IMoveLogic
    {
        private readonly IReactiveProperty<float> _transformablePositionX;
        private readonly IReactiveProperty<float> _transformablePositionY;
        private readonly IReactiveProperty<float> _transformableDirectionAngle;
        
        private readonly float _speed;

        private readonly IMoveRestrictionLogic _moveRestrictionLogic;

        public MoveLogic(
            IReactiveProperty<float> transformablePositionX,
            IReactiveProperty<float> transformablePositionY,
            IReactiveProperty<float> transformableDirectionAngle,
            float speed)
        {
            _transformablePositionX = transformablePositionX;
            _transformablePositionY = transformablePositionY;
            _transformableDirectionAngle = transformableDirectionAngle;
            
            _speed = speed;
        }
        
        public MoveLogic(
            IReactiveProperty<float> transformablePositionX,
            IReactiveProperty<float> transformablePositionY,
            IReactiveProperty<float> transformableDirectionAngle,
            float speed,
            IMoveRestrictionLogic moveRestrictionLogic)
            : this(transformablePositionX, transformablePositionY, transformableDirectionAngle, speed)
        {
            _moveRestrictionLogic = moveRestrictionLogic;
        }

        public virtual void Tick(float deltaTime)
        {
            float angle = _transformableDirectionAngle.Value;

            float x = _transformablePositionX.Value + (float)(_speed * Math.Sin(angle)) * deltaTime;
            float y = _transformablePositionY.Value + (float)(_speed * Math.Cos(angle)) * deltaTime;

            _moveRestrictionLogic?.Restrict(ref x, ref y);

            _transformablePositionX.Value = x;
            _transformablePositionY.Value = y;
        }
    }
}