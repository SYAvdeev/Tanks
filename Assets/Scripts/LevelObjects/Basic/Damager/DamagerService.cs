namespace Tanks.LevelObjects.Basic
{
    public class DamagerService : IDamagerService
    {
        private readonly DamagerModel _damagerModel;

        public DamagerService(DamagerModel damagerModel)
        {
            _damagerModel = damagerModel;
        }

        public void MakeDamage(IDamageableService damageableService)
        {
            damageableService.ConsumeDamage(_damagerModel.Config.Damage);
        }
    }
}