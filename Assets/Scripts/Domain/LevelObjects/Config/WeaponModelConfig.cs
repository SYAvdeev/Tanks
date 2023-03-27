namespace Domain.LevelObjects.Config
{
    public class WeaponModelConfig
    {
        public readonly string Name;
        public readonly float Damage;
        public readonly float BulletSpeed;
        public readonly float ReloadDelay;

        public WeaponModelConfig(string name, float bulletSpeed, float reloadDelay, float damage)
        {
            Name = name;
            BulletSpeed = bulletSpeed;
            ReloadDelay = reloadDelay;
            Damage = damage;
        }
    }
}