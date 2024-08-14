namespace Tanks.LevelObjects.Basic
{
    public class DamagerService : IDamagerService
    {
        private readonly IDamagerModel _damagerModel;

        public DamagerService(IDamagerModel damagerModel)
        {
            _damagerModel = damagerModel;
        }

        public void MakeDamage(IDamageableService damageableService)
        {
            damageableService.ConsumeDamage(_damagerModel.Config.Damage);
        }
    }
}