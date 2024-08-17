using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.Player
{
    public interface IPlayerModel
    {
        IPlayerConfig PlayerConfig { get; }
        IMovableModel Movable { get; }
        IDamageableModel DamageableModel { get; }
        public IWeaponConfig CurrentWeaponConfig { get; }
        internal void SetCurrentWeaponConfig(IWeaponConfig weaponConfig);
        event Action<IWeaponConfig> CurrentWeaponChanged;
        internal float CurrentReloadDelay { get; set; }
    }
}