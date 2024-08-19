using System.Collections.Generic;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Bullet
{
    [CreateAssetMenu(
        fileName = nameof(BulletSpawnConfig),
        menuName = "Custom/Game/LevelObjects/Spawn" + nameof(BulletSpawnConfig),
        order = 2)]
    public class BulletSpawnConfig : ConfigBase, IBulletSpawnConfig
    {
        [SerializeField] private IEnumerable<BulletConfig> _bulletConfigs;
        [SerializeField] private int _prewarmCount;

        public int PrewarmCount => _prewarmCount;
        public IEnumerable<BulletConfig> BulletConfigs => _bulletConfigs;
    }
}