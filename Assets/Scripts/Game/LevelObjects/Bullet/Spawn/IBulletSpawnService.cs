using UnityEngine;

namespace Tanks.Bullet
{
    public interface IBulletSpawnService
    {
        void SpawnBullet(IBulletConfig bulletConfig, Vector2 position, float rotation);
    }
}