using System;
using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class LookAtLogic : TickableLogic, ILookAtLogic
    {
        private readonly IReactiveProperty<float> _transformablePositionX;
        private readonly IReactiveProperty<float> _transformablePositionY;
        private readonly IReactiveProperty<float> _transformableDirectionAngle;
        private readonly IReactiveProperty<float> _targetPositionX;
        private readonly IReactiveProperty<float> _targetPositionY;

        public LookAtLogic(
            ITickService tickService,
            IReactiveProperty<float> transformablePositionX,
            IReactiveProperty<float> transformablePositionY, 
            IReactiveProperty<float> transformableDirectionAngle,
            IReactiveProperty<float> targetPositionX,
            IReactiveProperty<float> targetPositionY) : base(tickService)
        {
            _transformablePositionX = transformablePositionX;
            _transformablePositionY = transformablePositionY;
            _transformableDirectionAngle = transformableDirectionAngle;
            _targetPositionX = targetPositionX;
            _targetPositionY = targetPositionY;
        }

        public override void Tick(float deltaTime)
        {
            float x = _targetPositionX.Value - _transformablePositionX.Value;
            float y = _targetPositionY.Value - _transformablePositionY.Value;

            _transformableDirectionAngle.Value = (float)Math.Atan2(x, y);
        }
    }
}