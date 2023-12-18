using System.Collections.Generic;
using ReactiveTypes;

namespace Domain.Logic.Inventory
{
    public class InventoryLogic : IInventoryLogic
    {
        private readonly IReactiveProperty<string> _currentItemIDProperty;
        private readonly IReactiveList<string> _itemIDsProperty;
        
        private int _currentItemIndex;

        public InventoryLogic(
            IReactiveProperty<string> currentItemIDProperty,
            IReactiveList<string> itemIDsProperty)
        {
            _currentItemIDProperty = currentItemIDProperty;
            _itemIDsProperty = itemIDsProperty;
            
            string currentItemID = currentItemIDProperty.Value;
            _currentItemIndex = itemIDsProperty.IndexOf(currentItemID);
            
            itemIDsProperty.OnClear += ItemIDsPropertyOnOnClear;
            itemIDsProperty.OnRemoveItem += ItemIDsPropertyOnOnRemoveItem;
        }

        private void ItemIDsPropertyOnOnRemoveItem(GenericPairEventArgs<int, string> pair)
        {
            if (_currentItemIDProperty.Value == pair.Value)
            {
                SetCurrentItem("");
            }
        }

        private void ItemIDsPropertyOnOnClear(GenericEventArg<IEnumerable<string>> obj)
        {
            SetCurrentItem("");
        }

        public void SetCurrentItem(string id)
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
        
        private int CurrentItemIndex(string id) => _itemIDsProperty.IndexOf(id);
    }
}