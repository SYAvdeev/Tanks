using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    [Serializable]
    public class MovableData
    {
        public float DirectionAngle;
        public Vector2 Position;
        public Vector2 RestrictionMinPosition;
        public Vector2 RestrictionMaxPosition;
    }
}