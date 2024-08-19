using Tanks.Game.LevelObjects.Basic;
using Tanks.Game.LevelObjects.Bullet;

namespace Tanks.Game.LevelObjects.Player
{
    public interface IWeaponConfig
    {
        ISpawnableConfig SpawnableConfig { get; }
        IBulletConfig BulletConfig { get; }
        float ReloadDelay { get; }
    }
}