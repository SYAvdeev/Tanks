using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public class DamageableModel : IDamageableModel
    {
        private readonly DamageableData _data;

        public DamageableModel(DamageableData data, IDamageableConfig config)
        {
            _data = data;
            Config = config;
        }

        public event Action<float> HealthChanged;
        public IDamageableConfig Config { get; }
        
        public float GetCurrentHealth() => _data.CurrentHealth;

        void IDamageableModel.SetCurrentHealth(float health)
        {
            health = Mathf.Clamp(health, 0f, Config.MaxHealth);
                
            if (Mathf.Approximately(_data.CurrentHealth, health))
            {
                return;
            }
                
            _data.CurrentHealth = health;
            HealthChanged?.Invoke(health); 
        }
    }
}