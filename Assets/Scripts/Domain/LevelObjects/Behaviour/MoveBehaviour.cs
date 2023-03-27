using System;

namespace Domain.LevelObjects.Behaviour
{
    public class MoveBehaviour : TickBehaviour
    {
        private float _speed;
        private readonly LevelObjectModel _levelObjectModel;
        private float _speedX;
        private float _speedY;
        
        public MoveBehaviour(float speed, LevelObjectModel levelObjectModel)
        {
            _levelObjectModel = levelObjectModel;
            SetSpeed(speed);
            _levelObjectModel.OnRotationUpdate += OnRotationUpdate;
        }

        protected override void TickInternal(float deltaTime)
        {
            float x = _levelObjectModel.PositionX;
            float y = _levelObjectModel.PositionY;
            _levelObjectModel.SetPosition(x + _speedX * deltaTime, y + _speedY * deltaTime);
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
            OnRotationUpdate(_levelObjectModel.DirectionAngle);
        }

        public void OnRotationUpdate(float angle)
        {
            _speedX = (float)(_speed * Math.Sin(angle));
            _speedY = (float)(_speed * Math.Cos(angle));
        }
    }
}