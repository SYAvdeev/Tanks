using System.Collections.Generic;
using ReactiveTypes;

namespace Domain.Logic.Inventory
{
    public class InventoryLogic : IInventoryLogic
    {
        private readonly IReactiveProperty<int> _currentItemIDProperty;
        private readonly IReactiveList<int> _itemIDsProperty;
        
        private int _currentItemIndex;

        public InventoryLogic(
            IReactiveProperty<int> currentItemIDProperty,
            IReactiveList<int> itemIDsProperty)
        {
            _currentItemIDProperty = currentItemIDProperty;
            _itemIDsProperty = itemIDsProperty;
            
            int currentItemID = currentItemIDProperty.Value;
            _currentItemIndex = itemIDsProperty.IndexOf(currentItemID);
            
            itemIDsProperty.OnClear += ItemIDsPropertyOnOnClear;
            itemIDsProperty.OnRemoveItem += ItemIDsPropertyOnOnRemoveItem;
        }

        private void ItemIDsPropertyOnOnRemoveItem(GenericPairEventArgs<int, int> pair)
        {
            if (_currentItemIDProperty.Value == pair.Value)
            {
                SetCurrentItem(0);
            }
        }

        private void ItemIDsPropertyOnOnClear(GenericEventArg<IEnumerable<int>> obj)
        {
            SetCurrentItem(0);
        }

        public void SetCurrentItem(int id)
        {
            _currentItemIDProperty.Value = id;
            _currentItemIndex = CurrentItemIndex(id);
        }

        public void ChooseNextItem()
        {
            ++_currentItemIndex;
            if (_currentItemIndex >= _itemIDsProperty.Count)
            {
                _currentItemIndex = 0;
            }
            
            SetCurrentItem(_itemIDsProperty[_currentItemIndex]);
        }

        public void ChoosePreviousItem()
        {
            --_currentItemIndex;
            if (_currentItemIndex < 0)
            {
                _currentItemIndex = _itemIDsProperty.Count - 1;
            }
            
            SetCurrentItem(_itemIDsProperty[_currentItemIndex]);
        }
        
        private int CurrentItemIndex(int id) => _itemIDsProperty.IndexOf(id);
    }
}