using System.Collections.Generic;
using Data.Config;
using Domain.LevelObjects;
using Domain.LevelObjects.Config;
using UnityEngine;

namespace Presentation.LevelObjects
{
    public class PlayerPresenter : CharacterPresenter
    {
        [SerializeField] private Config _config;
        [SerializeField] private Transform _weaponsParent;
        private readonly List<KeyValuePair<string, GameObject>> _weapons = new();
        private PlayerModel PlayerModel => (PlayerModel)_levelObjectModel;

        public override void SetLevelObject(LevelObjectModel levelObjectModel)
        {
            base.SetLevelObject(levelObjectModel);
            PlayerModel.OnWeaponChanged += OnWeaponChanged;
            OnWeaponChanged(PlayerModel.CurrentWeaponModel);
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
                WeaponConfig weaponConfig = _config.GetWeaponConfig(weaponName);
                _weapons.Add(new KeyValuePair<string, GameObject>(weaponName, Instantiate(weaponConfig.Prefab, _weaponsParent)));
            }
        }
    }
}