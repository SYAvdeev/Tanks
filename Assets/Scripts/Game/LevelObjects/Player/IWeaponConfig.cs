using Tanks.Bullet;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.Player
{
    public interface IWeaponConfig
    {
        ISpawnableConfig SpawnableConfig { get; }
        IBulletConfig BulletConfig { get; }
        float ReloadDelay { get; }
    }
}