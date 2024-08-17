using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public interface IEnemyConfig
    {
        ISpawnableConfig SpawnableConfig { get; }
        IDamageableConfig DamageableConfig { get; }
        IDamagerConfig DamagerConfig { get; }
        IMovableConfig MovableConfig { get; }
    }
}