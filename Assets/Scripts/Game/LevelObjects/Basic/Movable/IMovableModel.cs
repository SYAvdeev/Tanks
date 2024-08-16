using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public interface IMovableModel
    {
        IMovableConfig Config { get; }
        event Action<float> DirectionAngleUpdated;
        event Action<Vector2> PositionUpdated;
        float DirectionAngle { get; }
        internal void SetDirectionAngle(float angle);
        Vector2 Position { get; }
        internal void SetPosition(Vector2 position);
    }
}