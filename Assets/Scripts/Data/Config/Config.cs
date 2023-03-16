using System.Collections.Generic;
using System.Linq;
using Model.LevelObjects.Config;
using Model.UseCase;
using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Main Config", order = 0)]
    public class Config : ScriptableObject, IConfigRepository
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private SpawnConfig _spawnConfig;
        [SerializeField] private List<EnemyConfig> _enemyConfigs;
        [SerializeField] private List<WeaponConfig> _weaponConfigs;
        public EnemyConfig GetEnemyConfig(string enemyName) => _enemyConfigs.Find(e => e.Name == enemyName);
        public WeaponConfig GetWeaponConfig(string weaponName) => _weaponConfigs.Find(w => w.Name == weaponName);
        public PlayerModelConfig PlayerModelConfig => _playerConfig.ToPlayerModelConfig();
        public SpawnModelConfig SpawnModelConfig => _spawnConfig.ToSpawnModelConfig();
        public List<EnemyModelConfig> EnemyModelConfigs => _enemyConfigs.Select(c => c.ToEnemyModelConfig()).ToList();
        public List<WeaponModelConfig> WeaponModelConfigs => _weaponConfigs.Select(c => c.ToWeaponModelConfig()).ToList();

        public WeaponModelConfig GetWeaponModelConfig(string weaponName) => GetWeaponConfig(weaponName).ToWeaponModelConfig();
        public EnemyModelConfig GetEnemyModelConfig(string enemyName) => GetEnemyConfig(enemyName).ToEnemyModelConfig();
    }
}