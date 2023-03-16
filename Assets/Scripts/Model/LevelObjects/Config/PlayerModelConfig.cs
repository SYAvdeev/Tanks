namespace Model.LevelObjects.Config
{
    public class PlayerModelConfig : CharacterModelConfig
    {
        public readonly float RotationSpeed;
        public readonly WeaponModelConfig DefaultWeaponModel;
        
        public PlayerModelConfig(float maxHealth, float protection, float speed, float rotationSpeed, WeaponModelConfig defaultWeaponModel) : base(maxHealth, protection, speed)
        {
            RotationSpeed = rotationSpeed;
            DefaultWeaponModel = defaultWeaponModel;
        }
    }
}