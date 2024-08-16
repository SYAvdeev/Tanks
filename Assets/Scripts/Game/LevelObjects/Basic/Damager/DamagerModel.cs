namespace Tanks.LevelObjects.Basic
{
    public class DamagerModel : IDamagerModel
    {
        public IDamagerConfig Config { get; }

        public DamagerModel(IDamagerConfig config)
        {
            Config = config;
        }
    }
}