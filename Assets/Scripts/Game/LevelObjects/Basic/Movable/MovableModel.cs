using System;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    public class MovableModel : IMovableModel
    {
        private readonly MovableData _movableData;

        public MovableModel(IMovableConfig config, MovableData movableData)
        {
            Config = config;
            _movableData = movableData;
        }

        public IMovableConfig Config { get; }

        public event Action<float> DirectionAngleUpdated;
        public event Action<Vector2> PositionUpdated;
        
        public float DirectionAngle => _movableData.DirectionAngle;

        public Vector2 Position => _movableData.Position;

        void IMovableModel.SetDirectionAngle(float angle)
        {
            angle %= 360f;

            if (angle < 0f)
            {
                angle += 360f;
            }
                
            if (Mathf.Approximately(_movableData.DirectionAngle, angle))
            {
                return;
            }

            _movableData.DirectionAngle = angle;
            DirectionAngleUpdated?.Invoke(angle);
        }

        void IMovableModel.SetPosition(Vector2 position)
        {
            if (_movableData.Position == position)
            {
                return;
            }

            _movableData.Position = position;
            PositionUpdated?.Invoke(position);
        }
    }
}