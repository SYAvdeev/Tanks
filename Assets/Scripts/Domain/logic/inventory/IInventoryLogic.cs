namespace Domain.Logic.Inventory
{
    public interface IInventoryLogic : ILogic
    {
        void SetCurrentItem(int id);

        void ChooseNextItem();

        void ChoosePreviousItem();
    }
}