using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Bullet
{
    public interface IBulletConfig
    {
        ISpawnableConfig SpawnableConfig { get; }
        IMovableConfig MovableConfig { get; }
        IDamagerConfig DamagerConfig { get; }
    }
}