using Domain.Logic.Tickable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class RotateLogic : TickableLogic, IRotateLogic
    {
        private readonly IReactiveProperty<float> _rotationSpeed;
        private readonly IReactiveProperty<float> _transformableDirectionAngle;

        public bool IsClockwise { private get; set; }

        public RotateLogic(
            ITickService tickService,
            IReactiveProperty<float> rotationSpeed,
            IReactiveProperty<float> transformableDirectionAngle) : base(tickService)
        {
            _rotationSpeed = rotationSpeed;
            _transformableDirectionAngle = transformableDirectionAngle;
            IsClockwise = false;
        }

        public override void Tick(float deltaTime)
        {
            _transformableDirectionAngle.Value += (IsClockwise ? 1f : -1f) * _rotationSpeed.Value * deltaTime;
        }
    }
}