using Domain.LevelObjects.Behaviour;
using Domain.LevelObjects.Config;

namespace Domain.LevelObjects
{
    public class EnemyModel : CharacterModel
    {
        private readonly LookAtBehaviour _lookAtBehaviour;
        private readonly DelayedAttackBehaviour _delayedAttackBehaviour;
        
        public EnemyModelConfig Config => (EnemyModelConfig)_characterModelConfig;

        public EnemyModel(float positionX, float positionY, float directionAngle, CharacterModel target, EnemyModelConfig enemyModelConfig) : base(positionX, positionY, directionAngle, enemyModelConfig)
        {
            _lookAtBehaviour = new LookAtBehaviour(this, target);
            _delayedAttackBehaviour = new DelayedAttackBehaviour(Config.Damage, Config.AttackDelay, target);

            _currentBehaviours.Add(_lookAtBehaviour);
            _currentBehaviours.Add(_delayedAttackBehaviour);
            
            _lookAtBehaviour.IsActive = true;
            _moveBehaviour.IsActive = true;
        }

        public void Initialize(float positionX, float positionY, EnemyModelConfig enemyModelConfig)
        {
            _characterModelConfig = enemyModelConfig;
            SetPosition(positionX, positionY);
            _delayedAttackBehaviour.SetParameters(enemyModelConfig.Damage, enemyModelConfig.AttackDelay);
            _moveBehaviour.SetSpeed(enemyModelConfig.Speed);
            OnRotationUpdate += _moveBehaviour.OnRotationUpdate;
            Health = MaxHealth;
            
            _lookAtBehaviour.IsActive = true;
            _moveBehaviour.IsActive = true;
        }

        public void SetAttack(bool isActive)
        {
            SetMove(!isActive);
            _delayedAttackBehaviour.IsActive = isActive;

            if (isActive)
            {
                _delayedAttackBehaviour.Delay = 0f;
            }
        }
    }
}