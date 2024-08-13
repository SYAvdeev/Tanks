namespace Tanks.LevelObjects.Basic
{
    public class DamagerModel
    {
        public IDamagerConfig Config { get; }

        public DamagerModel(IDamagerConfig config)
        {
            Config = config;
        }
    }
}