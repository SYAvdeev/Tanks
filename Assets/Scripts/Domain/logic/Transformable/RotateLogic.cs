using ReactiveTypes;

namespace Domain.Logic.Transformable
{
    public class RotateLogic : IRotateLogic
    {
        private readonly float _rotationSpeed;
        private readonly IReactiveProperty<float> _transformableDirectionAngle;

        public bool IsClockwise { private get; set; }

        public RotateLogic(float rotationSpeed, IReactiveProperty<float> transformableDirectionAngle)
        {
            _rotationSpeed = rotationSpeed;
            _transformableDirectionAngle = transformableDirectionAngle;
            IsClockwise = false;
        }

        public void Tick(float deltaTime)
        {
            _transformableDirectionAngle.Value += (IsClockwise ? 1f : -1f) * _rotationSpeed * deltaTime;
        }
    }
}