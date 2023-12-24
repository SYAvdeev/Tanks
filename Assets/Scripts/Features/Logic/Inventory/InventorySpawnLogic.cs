using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Features.Inventory;
using ReactiveTypes;
using Services;
using Services.Factory.ViewModel;
using UnityEngine;

namespace Features.Logic.Inventory
{
    public class InventorySpawnLogic : IInventorySpawnLogic, IInitializableAfterBuildLogic
    {
        private readonly IReactiveList<string> _itemIDs;
        private readonly ISpawnFeatureService _spawnFeatureService;
        private readonly IUniqueFeaturesContainer _uniqueFeaturesContainer;
        private readonly IFeature _inventoryFeature;

        private Transform _itemsParent;

        public event Action<IReadOnlyList<IFeature>> ItemsSpawned;

        public InventorySpawnLogic(
            IReactiveList<string> itemIDs,
            ISpawnFeatureService spawnFeatureService,
            IUniqueFeaturesContainer uniqueFeaturesContainer,
            IFeature inventoryFeature)
        {
            _itemIDs = itemIDs;
            _spawnFeatureService = spawnFeatureService;
            _uniqueFeaturesContainer = uniqueFeaturesContainer;
            _inventoryFeature = inventoryFeature;
        }
        
        public async UniTask Initialize()
        {
            List<IFeature> spawnedItems = new List<IFeature>(_itemIDs.Count);
            _itemsParent = _inventoryFeature.ViewRoot.GetViewFacade<InventoryViewFacade>(ViewType.Inventory).ItemsParent;

            foreach (string itemID in _itemIDs)
            {
                spawnedItems.Add(await CreateItem(itemID));
            }
            
            ItemsSpawned?.Invoke(spawnedItems);
        }
        
        private async UniTask<IFeature> CreateItem(string itemID)
        {
            IFeature itemFeature = await _spawnFeatureService.Create(itemID, _itemsParent);
            _uniqueFeaturesContainer.Add(itemFeature);
            return itemFeature;
        }
    }
}