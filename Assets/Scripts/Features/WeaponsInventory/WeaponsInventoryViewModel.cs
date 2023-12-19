using System;
using Domain.Logic;
using Domain.Logic.Inventory;
using Domain.Models;
using ReactiveTypes;

namespace Features.WeaponsInventory
{
    public class WeaponsInventoryViewModel : BaseViewModel
    {
        private readonly IInventoryLogic _inventoryLogic;
        public IReactiveProperty<string> CurrentItemID { get; }
        public IReactiveList<string> ItemIDs { get; }
        public event Action CreateItemsEvent;

        public WeaponsInventoryViewModel(
            IModel model,
            ILogicCollection logicCollection) :
            base(model, logicCollection)
        {
            CurrentItemID = model.GetProperty<string>(ModelPropertyName.CurrentItemID);
            ItemIDs = model.GetList<string>(ModelListName.ItemIDs);
            _inventoryLogic = logicCollection.Get<IInventoryLogic>();
            _inventoryLogic.InitializeEvent += InventoryLogicOnInitializeEvent;
        }

        private void InventoryLogicOnInitializeEvent()
        {
            CreateItemsEvent?.Invoke();
        }
    }
}