using System;
using System.Linq;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.Player
{
    public class PlayerModel : IPlayerModel
    {
        public IPlayerConfig PlayerConfig { get; }
        public IMovableModel Movable { get; }
        public IDamageableModel DamageableModel { get; }
        public IWeaponConfig CurrentWeaponConfig { get; private set; }

        public PlayerModel(IPlayerConfig playerConfig, IMovableModel movable, IDamageableModel damageableModel)
        {
            PlayerConfig = playerConfig;
            Movable = movable;
            DamageableModel = damageableModel;
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