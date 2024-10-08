﻿using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Player
{
    public class PlayerModel : IPlayerModel
    {
        public IPlayerConfig PlayerConfig { get; }
        public IMovableModel Movable { get; }
        public IDamageableModel Damageable { get; }
        public IWeaponConfig CurrentWeaponConfig { get; private set; }

        public PlayerModel(IPlayerConfig playerConfig)
        {
            PlayerConfig = playerConfig;
            Movable = new MovableModel(playerConfig.MovableConfig, new MovableData());
            Damageable = new DamageableModel(new DamageableData(), playerConfig.DamageableConfig);
        }

        public event Action<IWeaponConfig> CurrentWeaponChanged;

        float IPlayerModel.CurrentReloadDelay { get; set; }

        void IPlayerModel.SetCurrentWeaponConfig(IWeaponConfig weaponConfig)
        {
            CurrentWeaponConfig = weaponConfig;
            CurrentWeaponChanged?.Invoke(weaponConfig);
        }
    }
}