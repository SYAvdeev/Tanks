using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public class EnemyModel : IEnemyModel
    {
        public EnemyConfig Config { get; }
        public SpawnableModel SpawnableModel { get; }
        public DamageableModel DamageableModel { get; }
        public DamagerModel DamagerModel { get; }
        public MovableModel MovableModel { get; }

        public EnemyModel(
            EnemyConfig config, 
            SpawnableModel spawnableModel, 
            DamageableModel damageableModel,
            DamagerModel damagerModel, 
            MovableModel movableModel)
        {
            Config = config;
            SpawnableModel = spawnableModel;
            DamageableModel = damageableModel;
            DamagerModel = damagerModel;
            MovableModel = movableModel;
        }
    }
}