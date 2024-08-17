using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public interface IEnemyModel
    {
        EnemyConfig Config { get; }
        SpawnableModel SpawnableModel { get; }
        DamageableModel DamageableModel { get; }
        DamagerModel DamagerModel { get; }
        MovableModel MovableModel { get; }
    }
}