using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class RotateLogic : TickableLogic, IRotateLogic
    {
        private readonly IReactiveProperty<float> _rotationSpeed;
        private readonly IReactiveProperty<float> _directionAngle;

        public bool IsClockwise { private get; set; }

        public RotateLogic(
            ITickService tickService,
            IReactiveProperty<float> rotationSpeed,
            IReactiveProperty<float> directionAngle) : base(tickService)
        {
            _rotationSpeed = rotationSpeed;
            _directionAngle = directionAngle;
            IsClockwise = false;
        }

        public override void Tick(float deltaTime)
        {
            _directionAngle.Value += (IsClockwise ? 1f : -1f) * _rotationSpeed.Value * deltaTime;
        }
    }
}