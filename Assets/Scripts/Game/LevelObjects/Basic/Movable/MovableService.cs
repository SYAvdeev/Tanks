using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public class MovableService : IMovableService
    {
        private readonly IMovableModel _movableModel;

        public MovableService(IMovableModel movableModel)
        {
            _movableModel = movableModel;
        }

        public void SetPosition(Vector2 position)
        {
            _movableModel.SetPosition(position);
        }

        public void SetDirectionAngle(float directionAngle)
        {
            _movableModel.SetDirectionAngle(directionAngle);
        }

        public void MoveAlongDirection(float deltaTime)
        {
            if (deltaTime < 0f)
            {
                throw new ArgumentException("Delta time cannot be less than zero.");
            }

            float sin = Mathf.Sin(Mathf.Deg2Rad * _movableModel.DirectionAngle);
            float cos = Mathf.Cos(Mathf.Deg2Rad * _movableModel.DirectionAngle);
            
            Vector2 position = _movableModel.Position + deltaTime * _movableModel.Config.Velocity * (new Vector2(sin, cos));
            SetPosition(position);
        }

        public void RotateTowards(Vector2 targetPosition)
        {
            float x = targetPosition.x - _movableModel.Position.x;
            float y = targetPosition.y - _movableModel.Position.y;

            float angle = Mathf.Rad2Deg * (float)Math.Atan2(x, y);
            SetDirectionAngle(angle);
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

            float angle = _movableModel.DirectionAngle + (isClockwise ? 1f : -1f) * rotationVelocity * deltaTime;
            SetDirectionAngle(angle);
        }

        public void SetRestrictions(Vector2 minPosition, Vector2 maxPosition)
        {
            if (minPosition.x > maxPosition.x || minPosition.y > maxPosition.y)
            {
                throw new ArgumentException("Min position is larger than max position");
            }
            
            _movableModel.SetRestrictions(minPosition, maxPosition);
        }

        public bool IsInRestrictionBorders()
        {
            var restrictions = _movableModel.Restrictions;
            var position = _movableModel.Position;

            return position.x >= restrictions.minPosition.x && position.x <= restrictions.maxPosition.x &&
                   position.y >= restrictions.minPosition.y && position.y <= restrictions.maxPosition.y;
        }

        public void ClampPositionToRestrictionBorders()
        {
            var restrictions = _movableModel.Restrictions;
            var position = _movableModel.Position;

            position.x = Mathf.Clamp(position.x, restrictions.minPosition.x, restrictions.maxPosition.x);
            position.y = Mathf.Clamp(position.y, restrictions.minPosition.y, restrictions.maxPosition.y);
        }
    }
}