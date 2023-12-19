using System;

namespace Domain.Logic.Inventory
{
    public interface IInventoryLogic : ILogic
    {
        event Action InitializeEvent;
        void SetCurrentItem(string id);

        void ChooseNextItem();

        void ChoosePreviousItem();
    }
}