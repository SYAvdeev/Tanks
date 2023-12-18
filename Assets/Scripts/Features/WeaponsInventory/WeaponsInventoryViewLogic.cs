using System.Collections.Generic;
using System.Threading.Tasks;
using ReactiveTypes;
using Services.Factory.ViewModel;
using Services.PrototypeProvider;

namespace Features.WeaponsInventory
{
    public class WeaponsInventoryViewLogic : BaseViewLogic<WeaponsInventoryViewModel, WeaponsInventoryViewFacade>
    {
        private readonly IAssetsSpawnService _assetsSpawnService;
        private readonly IDictionary<string, FeatureViewRoot> _weaponViews;

        public WeaponsInventoryViewLogic(
            WeaponsInventoryViewModel viewModel, 
            WeaponsInventoryViewFacade viewFacade,
            IAssetsSpawnService assetsSpawnService) : 
            base(viewModel, viewFacade)
        {
            _assetsSpawnService = assetsSpawnService;
            _weaponViews = new Dictionary<string, FeatureViewRoot>();

            _viewModel.CurrentItemID.OnValueChanged += SetCurrentItemActive;
            _viewModel.ItemIDs.OnAddItem += ItemIDsOnOnAddItem;
            _viewModel.ItemIDs.OnRemoveItem += ItemIDsOnOnRemoveItem;

            SpawnItems();
        }

        private async void SpawnItems()
        {
            foreach (string itemID in _viewModel.ItemIDs)
            {
                await SpawnItem(itemID);
            }

            SetCurrentItemActive(_viewModel.CurrentItemID.Value);
        }

        private void ItemIDsOnOnRemoveItem(GenericPairEventArgs<int, string> obj)
        {
            string itemID = obj.Value;
            _assetsSpawnService.AddToPool(_weaponViews[itemID], itemID);
            _weaponViews.Remove(itemID);
        }

        private async void ItemIDsOnOnAddItem(GenericPairEventArgs<int, string> obj)
        {
            string itemID = obj.Value;
            await SpawnItem(itemID);
        }

        private async Task SpawnItem(string itemID)
        {
            FeatureViewRoot itemFeature = await
                _assetsSpawnService.Spawn<FeatureViewRoot>(itemID, _viewFacade.WeaponsParent);
            _weaponViews.Add(itemID, itemFeature);
        }

        private void SetCurrentItemActive(string currentItemID)
        {
            foreach (KeyValuePair<string, FeatureViewRoot> pair in _weaponViews)
            {
                pair.Value.gameObject.SetActive(pair.Key == currentItemID);
            }
        }
    }
}