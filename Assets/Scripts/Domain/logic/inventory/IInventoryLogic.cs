namespace Domain.Logic.Inventory
{
    public interface IInventoryLogic : ILogic
    {
        void SetCurrentItem(string id);

        void ChooseNextItem();

        void ChoosePreviousItem();
    }
}