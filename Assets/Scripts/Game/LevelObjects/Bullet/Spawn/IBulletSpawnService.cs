using System;
using UnityEngine;

namespace Tanks.Bullet
{
    public interface IBulletSpawnService : IDisposable
    {
        void SpawnBullet(IBulletConfig bulletConfig, Vector2 position, float rotation);
    }
}