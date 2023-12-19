using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
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