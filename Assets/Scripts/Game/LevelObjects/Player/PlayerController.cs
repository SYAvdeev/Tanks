using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Player
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

        public void Initialize()
        {
            _playerService.Model.Movable.PositionUpdated += MovableOnPositionUpdated;
            _playerService.Model.Movable.DirectionAngleUpdated += MovableOnDirectionAngleUpdated;
            _playerService.Model.Damageable.HealthChanged += DamageableOnHealthChanged;
            _playerService.Model.CurrentWeaponChanged += PlayerModelOnCurrentWeaponChanged;
            _playerView.DamageableView.CollidedWithDamager += DamageableViewOnCollidedWithDamager;
        }

        private void DamageableViewOnCollidedWithDamager(IDamagerService damagerService)
        {
            damagerService.MakeDamage(_playerService.DamageableService);
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
            float maxHealth = _playerService.Model.PlayerConfig.DamageableConfig.MaxHealth;
            var size = _playerView.HealthSpriteRenderer.size;
            size.x = _playerView.HealthBarMaxWidth * (health / maxHealth);
            _playerView.HealthSpriteRenderer.size = size;
        }

        private void MovableOnDirectionAngleUpdated(float directionAngle)
        {
            _playerView.RotateTransform.localRotation = Quaternion.Euler(0f, 0f, -directionAngle);
        }

        private void MovableOnPositionUpdated(Vector2 position)
        {
            _playerView.transform.localPosition = position;
        }

        public async UniTask InstantiateWeaponViews()
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
            _playerView.DamageableView.CollidedWithDamager -= DamageableViewOnCollidedWithDamager;
        }
    }
}