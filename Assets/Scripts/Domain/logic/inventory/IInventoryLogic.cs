namespace Domain.Logic.Weapons
{
    public interface IInventoryLogic
    {
        void SetCurrentItem(int id);

        void ChooseNextItem();

        void ChoosePreviousItem();
    }
}