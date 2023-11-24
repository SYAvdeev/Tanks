using System;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class MoveLogic : IMoveLogic
    {
        private readonly IReactiveProperty<float> _transformablePositionX;
        private readonly IReactiveProperty<float> _transformablePositionY;
        private readonly IReactiveProperty<float> _transformableDirectionAngle;
        
        private float _speed;
        protected float _cachedSpeedX;
        protected float _cachedSpeedY;

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
            
            SetSpeed(speed);
            _transformableDirectionAngle.OnValueChanged += OnDirectionAngleChanged;
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

        public void SetSpeed(float speed)
        {
            _speed = speed;
            OnDirectionAngleChanged(_transformableDirectionAngle.Value);
        }

        private void OnDirectionAngleChanged(float angle)
        {
            _cachedSpeedX = (float)(_speed * Math.Sin(angle));
            _cachedSpeedY = (float)(_speed * Math.Cos(angle));
        }
        
        public virtual void Tick(float deltaTime)
        {
            float x = _transformablePositionX.Value + _cachedSpeedX * deltaTime;
            float y = _transformablePositionY.Value + _cachedSpeedY * deltaTime;

            _moveRestrictionLogic?.Restrict(ref x, ref y);

            _transformablePositionX.Value = x;
            _transformablePositionY.Value = y;
        }
    }
}