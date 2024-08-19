using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public class EnemyModel : IEnemyModel
    {
        public IEnemyConfig Config { get; }
        public ISpawnableModel SpawnableModel { get; }
        public IDamageableModel DamageableModel { get; }
        public IDamagerModel DamagerModel { get; }
        public IMovableModel MovableModel { get; }
        public EnemyState CurrentState { get; private set; } = EnemyState.Move;

        public float CurrentAttackCooldown { get; private set; }

        public EnemyModel(EnemyConfig config)
        {
            Config = config;
            SpawnableModel = new SpawnableModel(config.SpawnableConfig);
            DamageableModel = new DamageableModel(new DamageableData(), config.DamageableConfig);
            DamagerModel = new DamagerModel(config.DamagerConfig);
            MovableModel = new MovableModel(config.MovableConfig, new MovableData());
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