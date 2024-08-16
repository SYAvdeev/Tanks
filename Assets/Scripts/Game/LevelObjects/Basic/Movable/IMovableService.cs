using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public interface IMovableService
    {
        public void MoveAlongDirection(float deltaTime);
        public void RotateTowards(Vector2 targetPosition);
        public void RotateWithVelocity(float rotationVelocity, bool isClockwise, float deltaTime);
    }
}