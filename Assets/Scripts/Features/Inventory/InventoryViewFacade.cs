using UnityEngine;

namespace Features.Inventory
{
    public class InventoryViewFacade : BaseViewFacade
    {
        [SerializeField]
        private Transform _itemsParent;

        public Transform ItemsParent => _itemsParent;
    }
}