﻿using System;
using System.Collections.Generic;
using Tanks.Utility;

namespace Tanks.Bullet
{
    public class BulletSpawnModel : IBulletSpawnModel
    {
        private readonly IList<IBulletService> _currentSpawnedBullets = new List<IBulletService>();
        
        public Pool<string, IBulletService> BulletsPool { get; } = new();

        public IEnumerable<IBulletService> CurrentSpawnedBullets => _currentSpawnedBullets;

        public event Action<IBulletService> BulletSpawned;
        public event Action<IBulletService> BulletAddedToPool;
        
        void IBulletSpawnModel.AddSpawnedBullet(IBulletService bulletService)
        {
            _currentSpawnedBullets.Add(bulletService);
        }

        void IBulletSpawnModel.RemoveSpawnedBulletToPool(IBulletService bulletService)
        {
            _currentSpawnedBullets.Remove(bulletService);
            BulletsPool.Add(bulletService.BulletModel.Spawnable.Config.ID, bulletService);
            BulletAddedToPool?.Invoke(bulletService);
        }
    }
}