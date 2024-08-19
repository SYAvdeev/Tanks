using System.Collections.Generic;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IPlayerConfig
    {
        IWeaponConfig FirstWeaponConfig { get; }
        float RotationVelocity { get; }
        IMovableConfig MovableConfig { get; }
        IDamageableConfig DamageableConfig { get; }
        IReadOnlyList<WeaponConfig> WeaponConfigs { get; }
    }
}