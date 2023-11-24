using ReactiveTypes;

namespace Domain.Logic.Weapons
{
    public class WeaponsInventoryLogic : IWeaponsInventoryLogic
    {
        private readonly IReactiveProperty<int> _weaponInventoryCurrentWeaponID;
        private readonly IReactiveList<int> _weaponInventoryIDs;
        
        private int _currentWeaponIndex;

        public WeaponsInventoryLogic(
            IReactiveProperty<int> weaponInventoryCurrentWeaponID,
            IReactiveList<int> weaponInventoryIDs)
        {
            _weaponInventoryCurrentWeaponID = weaponInventoryCurrentWeaponID;
            _weaponInventoryIDs = weaponInventoryIDs;
            
            int currentWeaponID = weaponInventoryCurrentWeaponID.Value;
            _currentWeaponIndex = weaponInventoryIDs.IndexOf(currentWeaponID);
        }

        public void SetWeapon(int id)
        {
            _weaponInventoryCurrentWeaponID.Value = id;
            _currentWeaponIndex = CurrentWeaponIndex(id);
        }

        public void NextWeapon()
        {
            ++_currentWeaponIndex;
            if (_currentWeaponIndex >= _weaponInventoryIDs.Count)
            {
                _currentWeaponIndex = 0;
            }
            
            SetWeapon(_weaponInventoryIDs[_currentWeaponIndex]);
        }

        public void PreviousWeapon()
        {
            --_currentWeaponIndex;
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = _weaponInventoryIDs.Count - 1;
            }
            
            SetWeapon(_weaponInventoryIDs[_currentWeaponIndex]);
        }
        
        private int CurrentWeaponIndex(int id) => _weaponInventoryIDs.IndexOf(id);
    }
}