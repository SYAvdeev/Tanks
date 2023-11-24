using System.Collections.Generic;
using Repositories.Configs;
using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Main Config", order = 0)]
    public class ConfigScriptableObject : ScriptableObject
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private SpawnConfig spawnConfig;
        [SerializeField] private List<EnemyConfig> _enemyConfigs;
        [SerializeField] private List<WeaponConfig> _weaponConfigs;
        public EnemyConfig GetEnemyConfig(string enemyName) => _enemyConfigs.Find(e => e.Name == enemyName);
        public WeaponConfig GetWeaponConfig(string weaponName) => _weaponConfigs.Find(w => w.Name == weaponName);
    }
}