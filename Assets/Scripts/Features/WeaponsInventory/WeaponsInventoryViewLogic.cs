using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Services;
using ReactiveTypes;
using Services;
using Services.Factory.ViewModel;

namespace Features.WeaponsInventory
{
    public class WeaponsInventoryViewLogic : BaseViewLogic<WeaponsInventoryViewModel, WeaponsInventoryViewFacade>
    {
        private readonly ISpawnFeatureService _spawnFeatureService;
        private readonly IUniqueFeaturesContainer _uniqueFeaturesContainer;
        private readonly IDictionary<string, FeatureViewRoot> _weaponsView;

        public WeaponsInventoryViewLogic(
            WeaponsInventoryViewModel viewModel, 
            WeaponsInventoryViewFacade viewFacade,
            ISpawnFeatureService spawnFeatureService,
            IUniqueFeaturesContainer uniqueFeaturesContainer) : 
            base(viewModel, viewFacade)
        {
            _spawnFeatureService = spawnFeatureService;
            _uniqueFeaturesContainer = uniqueFeaturesContainer;
            _weaponsView = new Dictionary<string, FeatureViewRoot>();

            _viewModel.CurrentItemID.OnValueChanged += SetCurrentItemActive;
            _viewModel.ItemIDs.OnAddItem += ItemIDsOnOnAddItem;
            _viewModel.ItemIDs.OnRemoveItem += ItemIDsOnOnRemoveItem;
            _viewModel.CreateItemsEvent += ViewModelOnCreateItemsEvent;
        }

        private async void ViewModelOnCreateItemsEvent()
        {
            foreach (string itemID in _viewModel.ItemIDs)
            {
                await CreateItem(itemID);
            }

            SetCurrentItemActive(_viewModel.CurrentItemID.Value);
        }

        private void ItemIDsOnOnRemoveItem(GenericPairEventArgs<int, string> obj)
        {
            FeatureViewRoot weaponView = _weaponsView[obj.Value];
            weaponView.gameObject.SetActive(false);
        }

        private async void ItemIDsOnOnAddItem(GenericPairEventArgs<int, string> obj)
        {
            string itemID = obj.Value;
            if (!_weaponsView.ContainsKey(itemID))
            {
                await CreateItem(itemID);
            }
        }

        private async Task CreateItem(string itemID)
        {
            IFeature itemFeature = await _spawnFeatureService.Create(itemID, _viewFacade.WeaponsParent);
            _uniqueFeaturesContainer.Add(itemFeature);
            _weaponsView[itemID] = itemFeature.ViewRoot;
        }

        private void SetCurrentItemActive(string currentItemID)
        {
            foreach (KeyValuePair<string, FeatureViewRoot> pair in _weaponsView)
            {
                pair.Value.gameObject.SetActive(pair.Key == currentItemID);
            }
        }
    }
}