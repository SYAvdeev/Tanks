using System.Linq;
using Tanks.Game.LevelObjects.Basic;
using Tanks.Game.Spawn.BulletSpawn;
using Tanks.Input;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly IInputService _inputService;
        private readonly IMovableService _movableService;
        private readonly IBulletSpawnService _bulletSpawnService;
        public IDamageableService DamageableService { get; }
        public IPlayerModel Model { get; }

        public PlayerService(
            IPlayerModel model,
            IInputService inputService,
            IBulletSpawnService bulletSpawnService)
        {
            Model = model;
            _inputService = inputService;
            _bulletSpawnService = bulletSpawnService;
            
            _movableService = new MovableService(model.Movable);
            DamageableService = new DamageableService(model.Damageable);
        }

        public void Initialize()
        {
            _inputService.ShootKeyDown += InputServiceOnShootKeyDown;
            _inputService.NextWeaponKeyDown += InputServiceOnNextWeaponKeyDown;
            _inputService.PreviousWeaponKeyDown += InputServiceOnPreviousWeaponKeyDown;
        }

        private void InputServiceOnShootKeyDown()
        {
            if (Mathf.Approximately(Model.CurrentReloadDelay, 0f))
            {
                var currentWeaponConfig = Model.CurrentWeaponConfig;
                var bulletConfig = currentWeaponConfig.BulletConfig;
                IMovableModel playerModelMovable = Model.Movable;
                _bulletSpawnService.SpawnBullet(bulletConfig, playerModelMovable.Position, playerModelMovable.DirectionAngle);
                Model.CurrentReloadDelay = currentWeaponConfig.ReloadDelay;
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
            
            float rotationVelocity = Model.PlayerConfig.RotationVelocity;
            if (_inputService.IsRotateClockwiseKeyPressed)
            {
                _movableService.RotateWithVelocity(rotationVelocity, true, deltaTime);
            }
            else if (_inputService.IsRotateCounterClockwiseKeyPressed)
            {
                _movableService.RotateWithVelocity(rotationVelocity, false, deltaTime);
            }

            if (Model.CurrentReloadDelay > 0f)
            {
                Model.CurrentReloadDelay = Mathf.Clamp(
                    Model.CurrentReloadDelay - deltaTime,
                    0f,
                    Model.CurrentReloadDelay);
            }
        }

        private void NextWeapon()
        {
            var currentWeaponConfig = Model.CurrentWeaponConfig;
            var weaponConfigs = Model.PlayerConfig.WeaponConfigs;
            var nextWeaponConfig = weaponConfigs.SkipWhile(x => x != (WeaponConfig)currentWeaponConfig)
                .Skip(1).DefaultIfEmpty(weaponConfigs[0]).FirstOrDefault();
            Model.SetCurrentWeaponConfig(nextWeaponConfig);
        }

        private void PreviousWeapon()
        {
            var currentWeaponConfig = Model.CurrentWeaponConfig;
            var weaponConfigs = Model.PlayerConfig.WeaponConfigs;
            var previousWeaponConfig = weaponConfigs.TakeWhile(x => x != (WeaponConfig)currentWeaponConfig)
                .DefaultIfEmpty(weaponConfigs[^1]).LastOrDefault();
            Model.SetCurrentWeaponConfig(previousWeaponConfig);
        }

        public void Dispose()
        {
            _inputService.ShootKeyDown += InputServiceOnShootKeyDown;
            _inputService.NextWeaponKeyDown += InputServiceOnNextWeaponKeyDown;
            _inputService.PreviousWeaponKeyDown += InputServiceOnPreviousWeaponKeyDown;
        }
    }
}