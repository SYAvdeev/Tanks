namespace Model.LevelObjects.Config
{
    public abstract class CharacterModelConfig
    {
        public readonly float MaxHealth;
        public readonly float Protection;
        public readonly float Speed;

        protected CharacterModelConfig(float maxHealth, float protection, float speed)
        {
            MaxHealth = maxHealth;
            Protection = protection;
            Speed = speed;
        }
    }
}