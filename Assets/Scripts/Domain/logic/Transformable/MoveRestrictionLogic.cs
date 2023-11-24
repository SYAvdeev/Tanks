using System;

namespace Domain.Logic.Transformable
{
    public class MoveRestrictionLogic : IMoveRestrictionLogic
    {
        private readonly float _minX;
        private readonly float _maxX;
        private readonly float _minY;
        private readonly float _maxY;

        public MoveRestrictionLogic(float minX, float maxX, float minY, float maxY)
        {
            _minX = minX;
            _maxX = maxX;
            _minY = minY;
            _maxY = maxY;
        }

        public void Restrict(ref float x, ref float y)
        {
            x = Math.Clamp(x, _minX, _maxX);
            y = Math.Clamp(y, _minY, _maxY);
        }
    }
}