using Domain.Logic.Inventory;
using Domain.Services.Input;

namespace Domain.Logic.Control
{
    public class InventoryInputControlLogic : IInventoryInputControlLogic
    {
        private readonly IInputService _inputService;
        private readonly IInventoryLogic _inventoryLogic;

        public InventoryInputControlLogic(IInputService inputService, IInventoryLogic inventoryLogic)
        {
            _inputService = inputService;
            _inventoryLogic = inventoryLogic;
            
            inputService.OnInput += InputServiceOnOnInput;
        }

        private void InputServiceOnOnInput(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.NextItem:
                    _inventoryLogic.ChooseNextItem();
                    break;
                case InputType.PreviousItem:
                    _inventoryLogic.ChoosePreviousItem();
                    break;
            }
        }
    }
}