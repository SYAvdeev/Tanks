using System;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    public class MovableModel
    {
        private readonly MovableData _movableData;
        public IMovableConfig Config { get; }

        public MovableModel(IMovableConfig config, MovableData movableData)
        {
            Config = config;
            _movableData = movableData;
        }

        public event Action<float> DirectionAngleUpdated;
        public event Action<Vector2> PositionUpdated;
        
        public float DirectionAngle
        {
            get => _movableData.DirectionAngle;
            internal set
            {
                value %= 360f;
                
                if (Mathf.Approximately(_movableData.DirectionAngle, value))
                {
                    return;
                }

                _movableData.DirectionAngle = value;
                DirectionAngleUpdated?.Invoke(value);
            }
        }

        public Vector2 Position
        {
            get => _movableData.Position;
            internal set
            {
                if (_movableData.Position == value)
                {
                    return;
                }

                _movableData.Position = value;
                PositionUpdated?.Invoke(value);
            }
        }
    }
}