using System.Linq;
using Tanks.Bullet;
using Tanks.Game.LevelObjects.Basic;
using Tanks.Input;
using UnityEngine;

namespace Tanks.Game.Player
{
    public class PlayerService : IPlayerService
    {
        private IPlayerModel _playerModel;
        private IMovableService _movableService;
        private IDamageableService _damageableService;
        private IInputService _inputService;
        private IBulletSpawnService _bulletSpawnService;

        public void Initialize()
        {
            _inputService.ShootKeyDown += InputServiceOnShootKeyDown;
            _inputService.NextWeaponKeyDown += InputServiceOnNextWeaponKeyDown;
            _inputService.PreviousWeaponKeyDown += InputServiceOnPreviousWeaponKeyDown;
        }

        private void InputServiceOnShootKeyDown()
        {
            if (Mathf.Approximately(_playerModel.CurrentReloadDelay, 0f))
            {
                var currentWeaponConfig = _playerModel.CurrentWeaponConfig;
                var bulletConfig = currentWeaponConfig.BulletConfig;
                IMovableModel playerModelMovable = _playerModel.Movable;
                _bulletSpawnService.SpawnBullet(bulletConfig, playerModelMovable.Position, playerModelMovable.DirectionAngle);
                _playerModel.CurrentReloadDelay = currentWeaponConfig.ReloadDelay;
            }
        }

        private void InputServiceOnNextWeaponKeyDown()
        {
            NextWeapon();
        }

        private void InputServiceOnPreviousWeaponKeyDown()
        {
            PreviousWeapon();
        }

        public void Update(float deltaTime)
        {
            if (_inputService.IsMoveKeyPressed)
            {
                _movableService.MoveAlongDirection(deltaTime);
            }
            
            float rotationVelocity = _playerModel.PlayerConfig.RotationVelocity;
            if (_inputService.IsRotateClockwiseKeyPressed)
            {
                _movableService.RotateWithVelocity(rotationVelocity, true, deltaTime);
            }
            else if (_inputService.IsRotateCounterClockwiseKeyPressed)
            {
                _movableService.RotateWithVelocity(rotationVelocity, false, deltaTime);
            }

            if (_playerModel.CurrentReloadDelay > 0f)
            {
                _playerModel.CurrentReloadDelay = Mathf.Clamp(
                    _playerModel.CurrentReloadDelay - deltaTime,
                    0f,
                    _playerModel.CurrentReloadDelay);
            }
        }

        public void NextWeapon()
        {
            var currentWeaponConfig = _playerModel.CurrentWeaponConfig;
            var weaponConfigs = _playerModel.PlayerConfig.WeaponConfigs;
            var nextWeaponConfig = weaponConfigs.SkipWhile(x => x != (WeaponConfig)currentWeaponConfig)
                .Skip(1).DefaultIfEmpty(weaponConfigs[0]).FirstOrDefault();
            _playerModel.SetCurrentWeaponConfig(nextWeaponConfig);
        }

        public void PreviousWeapon()
        {
            var currentWeaponConfig = _playerModel.CurrentWeaponConfig;
            var weaponConfigs = _playerModel.PlayerConfig.WeaponConfigs;
            var previousWeaponConfig = weaponConfigs.TakeWhile(x => x != (WeaponConfig)currentWeaponConfig)
                .DefaultIfEmpty(weaponConfigs[^1]).LastOrDefault();
            _playerModel.SetCurrentWeaponConfig(previousWeaponConfig);
        }

        public void Dispose()
        {
            _inputService.ShootKeyDown += InputServiceOnShootKeyDown;
            _inputService.NextWeaponKeyDown += InputServiceOnNextWeaponKeyDown;
            _inputService.PreviousWeaponKeyDown += InputServiceOnPreviousWeaponKeyDown;
        }
    }
}