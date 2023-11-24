namespace Domain.Logic.Weapons
{
    public interface IWeaponsInventoryLogic
    {
        void SetWeapon(int id);

        void NextWeapon();

        void PreviousWeapon();
    }
}