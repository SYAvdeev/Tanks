using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Enemy
{
    public interface IEnemyModel
    {
        IEnemyConfig Config { get; }
        ISpawnableModel Spawnable { get; }
        IDamageableModel Damageable { get; }
        IDamagerModel Damager { get; }
        IMovableModel Movable { get; }
        EnemyState CurrentState { get; }
        internal void SetState(EnemyState enemyState);
        float CurrentAttackCooldown { get; }
        internal void SetCurrentAttackCooldown(float cooldown);
        internal void SetInitialAttackCooldown();
    }
}