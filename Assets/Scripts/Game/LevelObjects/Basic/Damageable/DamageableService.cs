﻿using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public class DamageableService : IDamageableService
    {
        private readonly IDamageableModel _damageableModel;

        public DamageableService(IDamageableModel damageableModel)
        {
            _damageableModel = damageableModel;
        }

        public event Action OutOfHealth;
        
        public void ConsumeDamage(float damage)
        {
            if (damage < 0f)
            {
                throw new ArgumentException("Damage cannot be less than zero.");
            }

            float currentHealth = _damageableModel.GetCurrentHealth() - damage * (1f - _damageableModel.Config.Protection);
            _damageableModel.SetCurrentHealth(currentHealth);

            if (Mathf.Approximately(_damageableModel.GetCurrentHealth(), 0f))
            {
                OutOfHealth?.Invoke();
            }
        }

        public void RestoreHealth(float health)
        {
            if (health < 0f)
            {
                throw new ArgumentException("Health cannot be less than zero.");
            }
            
            _damageableModel.SetCurrentHealth(_damageableModel.GetCurrentHealth() + health);
        }

        public void SetMaxHealth()
        {
            _damageableModel.SetCurrentHealth(_damageableModel.Config.MaxHealth);
        }
    }
}