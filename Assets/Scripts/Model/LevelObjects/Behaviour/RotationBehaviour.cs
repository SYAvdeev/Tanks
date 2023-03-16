namespace Model.LevelObjects.Behaviour
{
    public class RotationBehaviour : TickBehaviour
    {
        private readonly float _rotationSpeed;
        private readonly LevelObjectModel _levelObjectModel;

        public bool IsClockwise { private get; set; }

        public RotationBehaviour(float rotationSpeed, LevelObjectModel levelObjectModel)
        {
            _rotationSpeed = rotationSpeed;
            _levelObjectModel = levelObjectModel;
            IsClockwise = false;
        }

        protected override void TickInternal(float deltaTime)
        {
            _levelObjectModel.DirectionAngle += (IsClockwise ? 1f : -1f) * _rotationSpeed * deltaTime;
        }
    }
}