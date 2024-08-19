using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Bullet
{
    public interface IBulletConfig
    {
        ISpawnableConfig SpawnableConfig { get; }
        IMovableConfig MovableConfig { get; }
        IDamagerConfig DamagerConfig { get; }
    }
}