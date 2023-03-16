using System;
using Model.LevelObjects.Behaviour;
using Model.LevelObjects.Config;

namespace Model.LevelObjects
{
    public abstract class CharacterModel : LevelObjectModel
    {
        protected readonly MoveBehaviour _moveBehaviour;
        protected CharacterModelConfig _characterModelConfig;
        public float Health { get; protected set; }
        public float MaxHealth => _characterModelConfig.MaxHealth;
        private float Protection => _characterModelConfig.Protection;

        public event Action<float> OnHealthChanged;

        public void AddDamage(float damage)
        {
            Health -= (int)(damage * Protection);
            OnHealthChanged?.Invoke(Health);

            if (Health <= 0f)
            {
                Destroy();
            }
        }

        protected CharacterModel(float positionX, float positionY, float directionAngle, CharacterModelConfig characterModelConfig) : base(positionX, positionY, directionAngle)
        {
            _characterModelConfig = characterModelConfig;
            Health = MaxHealth;
            _moveBehaviour = new MoveBehaviour(characterModelConfig.Speed, this);
            _currentBehaviours.Add(_moveBehaviour);
        }

        public void SetMove(bool isActive)
        {
            _moveBehaviour.IsActive = isActive;
        }

        public override void Destroy(bool clearDestroyEvent = false)
        {
            OnHealthChanged = null;
            base.Destroy(clearDestroyEvent);
        }
    }
}