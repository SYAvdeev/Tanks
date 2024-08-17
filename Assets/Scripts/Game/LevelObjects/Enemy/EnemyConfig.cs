using Tanks.Game.LevelObjects.Basic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Enemy
{
    [CreateAssetMenu(
        fileName = nameof(EnemyConfig),
        menuName = "Custom/Game/LevelObjects/" + nameof(EnemyConfig),
        order = 2)]
    public class EnemyConfig : ConfigBase, IEnemyConfig
    {
        [SerializeField] private SpawnableConfig _spawnableConfig;
        [SerializeField] private DamageableConfig _damageableConfig;
        [SerializeField] private DamagerConfig _damagerConfig;
        [SerializeField] private MovableConfig _movableConfig;

        public ISpawnableConfig SpawnableConfig => _spawnableConfig;
        public IDamageableConfig DamageableConfig => _damageableConfig;
        public IDamagerConfig DamagerConfig => _damagerConfig;
        public IMovableConfig MovableConfig => _movableConfig;
    }
}