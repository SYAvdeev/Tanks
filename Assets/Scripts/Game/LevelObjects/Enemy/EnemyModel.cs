using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Enemy
{
    public class EnemyModel : IEnemyModel
    {
        public IEnemyConfig Config { get; }
        public ISpawnableModel Spawnable { get; }
        public IDamageableModel Damageable { get; }
        public IDamagerModel Damager { get; }
        public IMovableModel Movable { get; }
        public EnemyState CurrentState { get; private set; } = EnemyState.Move;

        public float CurrentAttackCooldown { get; private set; }

        public EnemyModel(IEnemyConfig config)
        {
            Config = config;
            Spawnable = new SpawnableModel(config.SpawnableConfig);
            Damageable = new DamageableModel(new DamageableData(), config.DamageableConfig);
            Damager = new DamagerModel(config.DamagerConfig);
            Movable = new MovableModel(config.MovableConfig, new MovableData());
        }

        void IEnemyModel.SetState(EnemyState enemyState)
        {
            CurrentState = enemyState;
        }

        void IEnemyModel.SetCurrentAttackCooldown(float cooldown)
        {
            CurrentAttackCooldown = cooldown;
        }

        void IEnemyModel.SetInitialAttackCooldown()
        {
            CurrentAttackCooldown = Config.AttackCooldown;
        }
    }
}