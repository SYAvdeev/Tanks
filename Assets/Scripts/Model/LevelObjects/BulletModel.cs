using Model.LevelObjects.Behaviour;

namespace Model.LevelObjects
{
    public class BulletModel : LevelObjectModel
    {
        private const float Lifetime = 2f;

        private readonly MoveBehaviour _moveBehaviour;
        private readonly DelayedDestroyBehaviour _delayedDestroyBehaviour;
        public float Damage { get; set; }
        
        public BulletModel(float positionX, float positionY, float directionAngle, float speed) : base(positionX, positionY, directionAngle)
        {
            _moveBehaviour = new MoveBehaviour(speed, this);
            _delayedDestroyBehaviour = new DelayedDestroyBehaviour(Lifetime, this);
            _currentBehaviours.Add(_moveBehaviour);
            _currentBehaviours.Add(_delayedDestroyBehaviour);
            _moveBehaviour.IsActive = true;
            _delayedDestroyBehaviour.IsActive = true;
        }

        public void Initialize(float positionX, float positionY, float directionAngle, float speed)
        {
            DirectionAngle = directionAngle;
            SetPosition(positionX, positionY);

            _moveBehaviour.SetSpeed(speed);
            _delayedDestroyBehaviour.Reset();
            
            _moveBehaviour.IsActive = true;
            _delayedDestroyBehaviour.IsActive = true;
        }

        public void OnCharacterHit(CharacterModel characterModel)
        {
            characterModel.AddDamage(Damage);
            Destroy();
        }
    }
}