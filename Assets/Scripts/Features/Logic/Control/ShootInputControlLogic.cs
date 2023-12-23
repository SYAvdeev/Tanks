using System.Collections.Generic;
using Domain.Features;
using Domain.Logic.Control;
using Domain.Logic.Delayed;
using Domain.Models;
using Domain.Services;
using Domain.Services.Input;
using Features.Logic.GameSpawn;
using Features.Logic.Inventory;
using ReactiveTypes;
using Services;

namespace Features.Logic.Control
{
    public class ShootInputControlLogic : DelayedActionLogic, IShootInputControlLogic
    {
        private readonly IInputService _inputService;
        private readonly IUniqueFeaturesContainer _uniqueFeaturesContainer;
        private readonly IReactivePropertyReadonly<string> _currentWeapon;
        private readonly IGameSpawnLogic _gameSpawnLogic;
        private readonly IInventorySpawnLogic _inventorySpawnLogic;

        private bool _canShoot;
        
        public ShootInputControlLogic(
            ITickService tickService,
            IInputService inputService,
            IUniqueFeaturesContainer uniqueFeaturesContainer,
            IReactiveProperty<float> delay, 
            IReactiveProperty<float> currentDelay,
            IReactivePropertyReadonly<string> currentWeapon,
            IGameSpawnLogic gameSpawnLogic,
            IInventorySpawnLogic inventorySpawnLogic) :
            base(tickService, delay, currentDelay)
        {
            _inputService = inputService;
            _uniqueFeaturesContainer = uniqueFeaturesContainer;
            _currentWeapon = currentWeapon;
            _gameSpawnLogic = gameSpawnLogic;
            _inventorySpawnLogic = inventorySpawnLogic;

            inputService.OnInput += InputServiceOnOnInput;
            currentWeapon.OnValueChanged += OnCurrentWeaponChanged;
            inventorySpawnLogic.ItemsSpawned += InventorySpawnLogicOnItemsSpawned;
            
            _canShoot = true;
        }

        private void InventorySpawnLogicOnItemsSpawned(IReadOnlyList<IFeature> obj)
        {
            OnCurrentWeaponChanged(_currentWeapon.Value);
        }

        private void OnCurrentWeaponChanged(string itemID)
        {
            IFeatureBase feature = _uniqueFeaturesContainer.GetFeature(itemID);
            IReactiveProperty<float> currentWeaponDelay = feature.Model.GetProperty<float>(ModelPropertyName.Delay);
            Delay.Value = currentWeaponDelay.Value;
            CurrentDelay.Value = currentWeaponDelay.Value;
        }

        private void InputServiceOnOnInput(InputType inputType)
        {
            if (!_canShoot)
            {
                return;
            }
            
            switch (inputType)
            {
                case InputType.Shoot:
                    _gameSpawnLogic.SpawnOnShoot();
                    _canShoot = false;
                    Subscribe(true);
                    break;
            }
        }

        protected override void Action()
        {
            _canShoot = true;
            Subscribe(false);
        }
    }
}