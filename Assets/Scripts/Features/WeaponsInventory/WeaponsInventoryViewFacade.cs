using UnityEngine;

namespace Features.WeaponsInventory
{
    public class WeaponsInventoryViewFacade : BaseViewFacade
    {
        [SerializeField]
        private Transform _weaponsParent;

        public Transform WeaponsParent => _weaponsParent;
    }
}