using System;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    public class MovableService : IMovableService
    {
        private readonly MovableModel _movableModel;

        public MovableService(MovableModel movableModel)
        {
            _movableModel = movableModel;
        }

        public void MoveAlongDirection(float deltaTime)
        {
            if (deltaTime < 0f)
            {
                throw new ArgumentException("Delta time cannot be less than zero.");
            }

            float sin = Mathf.Sin(Mathf.Deg2Rad * _movableModel.DirectionAngle);
            float cos = Mathf.Cos(Mathf.Deg2Rad * _movableModel.DirectionAngle);
            _movableModel.Position += deltaTime * _movableModel.Config.Velocity * (new Vector2(sin, cos));
        }

        public void RotateTowards(Vector2 targetPosition)
        {
            float x = targetPosition.x - _movableModel.Position.x;
            float y = targetPosition.y - _movableModel.Position.y;

            _movableModel.DirectionAngle = Mathf.Rad2Deg * (float)Math.Atan2(x, y);
        }

        public void RotateWithVelocity(float rotationVelocity, bool isClockwise, float deltaTime)
        {
            if (deltaTime < 0f)
            {
                throw new ArgumentException("Delta time cannot be less than zero.");
            }
            
            if (rotationVelocity < 0f)
            {
                throw new ArgumentException("Rotation velocity cannot be less than zero.");
            }
            
            _movableModel.DirectionAngle += (isClockwise ? 1f : -1f) * rotationVelocity * deltaTime;
        }
    }
}