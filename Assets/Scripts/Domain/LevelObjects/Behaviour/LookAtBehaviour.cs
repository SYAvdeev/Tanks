using System;

namespace Domain.LevelObjects.Behaviour
{
    public class LookAtBehaviour : TickBehaviour
    {
        private readonly LevelObjectModel _levelObjectModel;
        private readonly LevelObjectModel _target;

        public LookAtBehaviour(LevelObjectModel levelObjectModel, LevelObjectModel target)
        {
            _levelObjectModel = levelObjectModel;
            _target = target;
        }

        protected override void TickInternal(float deltaTime)
        {
            float x = _target.PositionX - _levelObjectModel.PositionX;
            float y = _target.PositionY - _levelObjectModel.PositionY;

            _levelObjectModel.DirectionAngle = (float)Math.Atan2(x, y);
        }
    }
}