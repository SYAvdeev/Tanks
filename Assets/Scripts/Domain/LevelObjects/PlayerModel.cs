using System;
using System.Collections.Generic;
using Domain.LevelObjects.Behaviour;
using Domain.LevelObjects.Config;
using Domain.LevelObjects.Spawner;

namespace Domain.LevelObjects
{
    public class PlayerModel : CharacterModel
    {
        private readonly RotationBehaviour _rotationBehaviour;
        private readonly DelayedDeactivateBehaviour _delayedDeactivateBehaviour;
        private readonly LevelObjectModelsSpawner _levelObjectModelsSpawner;

        private readonly float _maxX;
        private List<WeaponModelConfig> _weaponConfigs;
        private int _currentWeaponIndex;

        public event Action<BulletModel> OnShoot;
        public event Action<WeaponModelConfig> OnWeaponChanged;

        private PlayerModelConfig PlayerModelConfig => (PlayerModelConfig)_characterModelConfig;
        public WeaponModelConfig CurrentWeaponModel => _weaponConfigs[_currentWeaponIndex];

        public PlayerModel(float positionX, float positionY, float directionAngle, float maxX, PlayerModelConfig playerModelConfig, List<WeaponModelConfig> weaponConfigs, LevelObjectModelsSpawner levelObjectModelsSpawner) : base(positionX, positionY, directionAngle, playerModelConfig)
        {
            _maxX = maxX;
            _levelObjectModelsSpawner = levelObjectModelsSpawner;
            
            _rotationBehaviour = new RotationBehaviour(PlayerModelConfig.RotationSpeed, this);
            _delayedDeactivateBehaviour = new DelayedDeactivateBehaviour();
            
            _currentBehaviours.Add(_rotationBehaviour);
            _currentBehaviours.Add(_delayedDeactivateBehaviour);

            _weaponConfigs = weaponConfigs;
            _currentWeaponIndex = weaponConfigs.IndexOf(playerModelConfig.DefaultWeaponModel);
            SetWeapon(CurrentWeaponModel);
        }

        public void Initialize(float positionX, float positionY, float directionAngle)
        {
            SetPosition(positionX, positionY);
            DirectionAngle = directionAngle;
            _currentWeaponIndex = _weaponConfigs.IndexOf(PlayerModelConfig.DefaultWeaponModel);
            SetWeapon(CurrentWeaponModel);
            OnRotationUpdate += _moveBehaviour.OnRotationUpdate;
            Health = MaxHealth;
        }

        public override void SetPosition(float positionX, float positionY)
        {
            PositionX = Math.Clamp(positionX, -_maxX, _maxX);
            PositionY = Math.Clamp(positionY, -1f, 1f);
            CallOnPositionUpdate(PositionX, PositionY);
        }
        
        public void StartRotation(bool isClockwise)
        {
            _rotationBehaviour.IsClockwise = isClockwise;
            _rotationBehaviour.IsActive = true;
        }

        public void StopRotation()
        {
            _rotationBehaviour.IsActive = false;
        }

        private void SetWeapon(WeaponModelConfig currentWeaponModel)
        {
            _delayedDeactivateBehaviour.Delay = currentWeaponModel.ReloadDelay;
        }

        public void Shoot()
        {
            if (!_delayedDeactivateBehaviour.IsActive)
            {
                BulletModel bulletModel = _levelObjectModelsSpawner.SpawnBullet(PositionX, PositionY, DirectionAngle, CurrentWeaponModel.BulletSpeed);
                bulletModel.Damage = CurrentWeaponModel.Damage;
                _delayedDeactivateBehaviour.IsActive = true;
                OnShoot?.Invoke(bulletModel);
            }
        }

        public void NextWeapon()
        {
            ++_currentWeaponIndex;
            if (_currentWeaponIndex >= _weaponConfigs.Count)
            {
                _currentWeaponIndex = 0;
            }

            SetWeapon(CurrentWeaponModel);
            OnWeaponChanged?.Invoke(CurrentWeaponModel);
        }
        
        public void PreviousWeapon()
        {
            --_currentWeaponIndex;
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = _weaponConfigs.Count - 1;
            }

            SetWeapon(CurrentWeaponModel);
            OnWeaponChanged?.Invoke(CurrentWeaponModel);
        }

        public override void Destroy(bool clearDestroyEvent = false)
        {
            OnShoot = null;
            OnWeaponChanged = null;
            base.Destroy(clearDestroyEvent);
        }
    }
}