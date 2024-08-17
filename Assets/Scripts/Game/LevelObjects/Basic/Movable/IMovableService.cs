using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public interface IMovableService
    {
        void MoveAlongDirection(float deltaTime);
        void RotateTowards(Vector2 targetPosition);
        void RotateWithVelocity(float rotationVelocity, bool isClockwise, float deltaTime);
        void SetRestrictions(Vector2 minPosition, Vector2 maxPosition);
        bool IsInRestrictionBorders();
    }
}