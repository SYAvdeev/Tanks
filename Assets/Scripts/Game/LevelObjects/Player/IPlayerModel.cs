using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IPlayerModel
    {
        IPlayerConfig PlayerConfig { get; }
        IMovableModel Movable { get; }
        IDamageableModel Damageable { get; }
        public IWeaponConfig CurrentWeaponConfig { get; }
        internal void SetCurrentWeaponConfig(IWeaponConfig weaponConfig);
        event Action<IWeaponConfig> CurrentWeaponChanged;
        internal float CurrentReloadDelay { get; set; }
    }
}