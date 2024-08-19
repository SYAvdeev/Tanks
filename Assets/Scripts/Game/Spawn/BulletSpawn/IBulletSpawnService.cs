using System;
using Tanks.Game.LevelObjects.Bullet;
using UnityEngine;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public interface IBulletSpawnService : IDisposable
    {
        void SpawnBullet(IBulletConfig bulletConfig, Vector2 position, float rotation);
    }
}