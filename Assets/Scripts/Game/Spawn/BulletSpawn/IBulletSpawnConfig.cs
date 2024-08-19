using System.Collections.Generic;
using Tanks.Game.LevelObjects.Bullet;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public interface IBulletSpawnConfig
    {
        int PrewarmCount { get; }
        IEnumerable<BulletConfig> BulletConfigs { get; }
    }
}