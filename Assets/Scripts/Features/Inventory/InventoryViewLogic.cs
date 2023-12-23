using System.Collections.Generic;

namespace Features.Inventory
{
    public class InventoryViewLogic : BaseViewLogic<InventoryViewModel, InventoryViewFacade>
    {
        public InventoryViewLogic(
            InventoryViewModel viewModel, 
            InventoryViewFacade viewFacade) : 
            base(viewModel, viewFacade)
        {
            _viewModel.CurrentItem.OnValueChanged += SetCurrentItemActive;
            _viewModel.ItemsSpawned += ViewModelOnItemsSpawned;
        }

        private void ViewModelOnItemsSpawned(IEnumerable<IFeature> obj)
        {
            SetCurrentItemActive(_viewModel.CurrentItem.Value);
        }

        private void SetCurrentItemActive(IFeature currentItem)
        {
            foreach (IFeature item in _viewModel.Items)
            {
                item.ViewRoot.gameObject.SetActive(item.ID == currentItem.ID);
            }
        }
    }
}