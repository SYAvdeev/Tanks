﻿using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Tanks.Game.Player
{
    public class PlayerController : IPlayerController
    {
        private readonly PlayerView _playerView;
        private readonly IPlayerService _playerService;

        private readonly IDictionary<string, GameObject> _weaponViews = new Dictionary<string, GameObject>();

        public PlayerController(PlayerView playerView, IPlayerService playerService)
        {
            _playerView = playerView;
            _playerService = playerService;
        }

        public async UniTask Initialize()
        {
            _playerService.Model.Movable.PositionUpdated += MovableOnPositionUpdated;
            _playerService.Model.Movable.DirectionAngleUpdated += MovableOnDirectionAngleUpdated;
            _playerService.Model.Damageable.HealthChanged += DamageableOnHealthChanged;
            _playerService.Model.CurrentWeaponChanged += PlayerModelOnCurrentWeaponChanged;
            await InstantiateWeaponViews();
        }

        private void PlayerModelOnCurrentWeaponChanged(IWeaponConfig weaponConfig)
        {
            foreach (var (key, value) in _weaponViews)
            {
                value.SetActive(key == weaponConfig.SpawnableConfig.ID);
            }
        }

        private void DamageableOnHealthChanged(float health)
        {
            var size = _playerView.HealthSpriteRenderer.size;
            size.x = health;
            _playerView.HealthSpriteRenderer.size = size;
        }

        private void MovableOnDirectionAngleUpdated(float directionAngle)
        {
            _playerView.transform.localRotation = Quaternion.Euler(0f, 0f, directionAngle);
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _playerView.transform.localPosition = position;
        }

        private async UniTask InstantiateWeaponViews()
        {
            foreach (var weaponConfig in _playerService.Model.PlayerConfig.WeaponConfigs)
            {
                var weaponObject = await weaponConfig.SpawnableConfig.AssetReference
                    .InstantiateAsync(_playerView.WeaponViewParent);
                
                _weaponViews.Add(weaponConfig.SpawnableConfig.ID, weaponObject);
            }
        }

        public void Dispose()
        {
            _playerService.Model.Movable.PositionUpdated -= MovableOnPositionUpdated;
            _playerService.Model.Movable.DirectionAngleUpdated -= MovableOnDirectionAngleUpdated;
            _playerService.Model.Damageable.HealthChanged -= DamageableOnHealthChanged;
            _playerService.Model.CurrentWeaponChanged -= PlayerModelOnCurrentWeaponChanged;
        }
    }
}