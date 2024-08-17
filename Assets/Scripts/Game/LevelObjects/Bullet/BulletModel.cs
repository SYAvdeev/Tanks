using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Bullet
{
    public class BulletModel : IBulletModel
    {
        public IMovableModel Movable { get; }
        public IDamagerModel Damager { get; }
        public ISpawnableModel Spawnable { get; }
        public IBulletConfig Config { get; }

        public BulletModel(IBulletConfig config)
        {
            Config = config;
            Movable = new MovableModel(config.MovableConfig, new MovableData());
            Damager = new DamagerModel(config.DamagerConfig);
            Spawnable = new SpawnableModel(config.SpawnableConfig);
        }
    }
}