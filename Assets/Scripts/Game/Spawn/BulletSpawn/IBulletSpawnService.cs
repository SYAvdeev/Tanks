using System;
using Tanks.Game.LevelObjects.Bullet;
using UnityEngine;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public interface IBulletSpawnService : IDisposable
    {
        IBulletSpawnModel Model { get; }
        void SpawnBullet(IBulletConfig bulletConfig, Vector2 position, float directionAngle);
        void Update(float deltaTime);
    }
}