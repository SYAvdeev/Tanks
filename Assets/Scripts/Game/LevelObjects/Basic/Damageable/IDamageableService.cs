using System;

namespace Tanks.Game.LevelObjects.Basic
{
    public interface IDamageableService
    {
        event Action OutOfHealth;
        void ConsumeDamage(float damage);
        void RestoreHealth(float health);
    }
}