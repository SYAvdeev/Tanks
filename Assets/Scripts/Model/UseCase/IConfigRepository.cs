using System.Collections.Generic;
using Model.LevelObjects.Config;

namespace Model.UseCase
{
    public interface IConfigRepository
    {
        public PlayerModelConfig PlayerModelConfig { get; }
        public SpawnModelConfig SpawnModelConfig { get; }
        public List<EnemyModelConfig> EnemyModelConfigs { get; }
        public List<WeaponModelConfig> WeaponModelConfigs { get; }
        public EnemyModelConfig GetEnemyModelConfig(string enemyName);
        public WeaponModelConfig GetWeaponModelConfig(string weaponName);
        
    }
}