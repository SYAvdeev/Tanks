namespace Domain.LevelObjects.Config
{
    public class EnemyModelConfig : CharacterModelConfig
    {
        public readonly string Name;
        public readonly float Damage;
        public readonly float AttackDelay;

        public EnemyModelConfig(string name, float damage, float maxHealth, float protection, float speed, float attackDelay) : base(maxHealth, protection, speed)
        {
            Name = name;
            Damage = damage;
            AttackDelay = attackDelay;
        }
    }
}