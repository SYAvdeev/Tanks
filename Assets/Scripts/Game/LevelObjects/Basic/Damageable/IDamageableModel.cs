using System;

namespace Tanks.LevelObjects.Basic
{
    public interface IDamageableModel
    {
        event Action<float> HealthChanged;
        IDamageableConfig Config { get; }
        float GetCurrentHealth();
        internal void SetCurrentHealth(float health);
    }
}