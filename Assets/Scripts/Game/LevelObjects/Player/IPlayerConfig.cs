using System.Collections.Generic;
using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IPlayerConfig
    {
        Vector2 InitialPosition { get; }
        IWeaponConfig FirstWeaponConfig { get; }
        float RotationVelocity { get; }
        IMovableConfig MovableConfig { get; }
        IDamageableConfig DamageableConfig { get; }
        IReadOnlyList<WeaponConfig> WeaponConfigs { get; }
    }
}