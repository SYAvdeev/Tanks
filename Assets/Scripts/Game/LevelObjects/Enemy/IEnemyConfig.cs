using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public interface IEnemyConfig
    {
        float AttackCooldown { get; }
        ISpawnableConfig SpawnableConfig { get; }
        IDamageableConfig DamageableConfig { get; }
        IDamagerConfig DamagerConfig { get; }
        IMovableConfig MovableConfig { get; }
    }
}