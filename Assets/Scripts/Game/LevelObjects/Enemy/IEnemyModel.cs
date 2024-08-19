using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public interface IEnemyModel
    {
        IEnemyConfig Config { get; }
        ISpawnableModel SpawnableModel { get; }
        IDamageableModel DamageableModel { get; }
        IDamagerModel DamagerModel { get; }
        IMovableModel MovableModel { get; }
        EnemyState CurrentState { get; }
        internal void SetState(EnemyState enemyState);
        float CurrentAttackCooldown { get; }
        internal void SetCurrentAttackCooldown(float cooldown);
        internal void SetInitialAttackCooldown();
    }
}