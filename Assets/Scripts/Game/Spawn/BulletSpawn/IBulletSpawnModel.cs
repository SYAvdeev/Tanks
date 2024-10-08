﻿using System;
using System.Collections.Generic;
using Tanks.Game.LevelObjects.Bullet;
using Tanks.Utility;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public interface IBulletSpawnModel
    {
        IBulletSpawnConfig Config { get; }
        Pool<string, IBulletService> BulletsPool { get; }
        IEnumerable<IBulletService> CurrentSpawnedBullets { get; }
        event Action<IBulletService> BulletSpawned;
        event Action<IBulletService> BulletRemovedToPool;
        internal void AddSpawnedBullet(IBulletService bulletService);
        internal void RemoveSpawnedBulletToPool(IBulletService bulletService);
    }
}