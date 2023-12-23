using System;
using System.Collections.Generic;
using Domain.Logic;
using Domain.Models;
using Features.Logic.Inventory;
using ReactiveTypes;
using Services;

namespace Features.Inventory
{
    public class InventoryViewModel : BaseViewModel
    {
        private readonly IUniqueFeaturesContainer _uniqueFeaturesContainer;
        private readonly IInventorySpawnLogic _inventorySpawnLogic;
        public IReactiveProperty<IFeature> CurrentItem { get; }
        public IReactiveList<IFeature> Items { get; private set; }
        public event Action<IEnumerable<IFeature>> ItemsSpawned;

        public InventoryViewModel(
            IModel model,
            ILogicCollection logicCollection,
            IUniqueFeaturesContainer uniqueFeaturesContainer) :
            base(model, logicCollection)
        {
            _uniqueFeaturesContainer = uniqueFeaturesContainer;
            _inventorySpawnLogic = logicCollection.Get<IInventorySpawnLogic>();
            _inventorySpawnLogic.ItemsSpawned += InventorySpawnLogicOnItemsSpawned;

            CurrentItem = new ReactiveProperty<IFeature>();
        }

        private void InventorySpawnLogicOnItemsSpawned(IReadOnlyList<IFeature> items)
        {
            Items = new ReactiveList<IFeature>(items);
            IReactiveProperty<string> currentItemIDProperty = _model.GetProperty<string>(ModelPropertyName.CurrentItemID);
            currentItemIDProperty.OnValueChanged += CurrentItemIDPropertyOnOnValueChanged;
            CurrentItemIDPropertyOnOnValueChanged(currentItemIDProperty.Value);
            ItemsSpawned?.Invoke(items);
        }

        private void CurrentItemIDPropertyOnOnValueChanged(string itemID)
        {
            CurrentItem.Value = _uniqueFeaturesContainer.GetFeature(itemID);
        }
    }
}