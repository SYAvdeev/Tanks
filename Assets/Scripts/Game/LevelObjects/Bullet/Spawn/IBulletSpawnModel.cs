using System;
using System.Collections.Generic;
using Tanks.Utility;

namespace Tanks.Bullet
{
    public interface IBulletSpawnModel
    {
        Pool<string, IBulletService> BulletsPool { get; }
        IEnumerable<IBulletService> CurrentSpawnedBullets { get; }
        event Action<IBulletService> BulletSpawned;
        event Action<IBulletService> BulletAddedToPool;
        internal void AddSpawnedBullet(IBulletService bulletService);
        internal void RemoveSpawnedBulletToPool(IBulletService bulletService);
    }
}