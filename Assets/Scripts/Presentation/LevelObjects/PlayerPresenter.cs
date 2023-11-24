using System.Collections.Generic;
using Data.Config;
using Domain.Model.Config;
using Domain.Models;
using Repositories.Configs;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public class PlayerPresenter : CharacterPresenter
    {
        [SerializeField] private ConfigScriptableObject configScriptableObject;
        [SerializeField] private Transform _weaponsParent;
        private readonly List<KeyValuePair<string, GameObject>> _weapons = new();
        private WeaponsInventoryModel WeaponsInventoryModel => (WeaponsInventoryModel)TransformableModel;

        public override void SetLevelObject(TransformableModel transformableModel)
        {
            base.SetLevelObject(transformableModel);
            WeaponsInventoryModel.OnWeaponChanged += OnWeaponChanged;
            OnWeaponChanged(WeaponsInventoryModel.CurrentWeaponModel);
        }

        private void OnWeaponChanged(WeaponModelConfig weaponModelConfig)
        {
            string weaponName = weaponModelConfig.Name;
            
            bool contains = false;
            for (int i = 0; i < _weapons.Count; i++)
            {
                _weapons[i].Value.SetActive(_weapons[i].Key == weaponName);
                if (_weapons[i].Key == weaponName)
                {
                    contains = true;
                }
            }

            if (!contains)
            {
                WeaponConfig weaponConfig = configScriptableObject.GetWeaponConfig(weaponName);
                _weapons.Add(new KeyValuePair<string, GameObject>(weaponName, Instantiate(weaponConfig.Prefab, _weaponsParent)));
            }
        }
    }
}