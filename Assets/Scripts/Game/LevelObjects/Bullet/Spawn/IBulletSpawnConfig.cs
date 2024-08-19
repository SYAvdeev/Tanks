using System.Collections.Generic;

namespace Tanks.Bullet
{
    public interface IBulletSpawnConfig
    {
        int PrewarmCount { get; }
        IEnumerable<BulletConfig> BulletConfigs { get; }
    }
}