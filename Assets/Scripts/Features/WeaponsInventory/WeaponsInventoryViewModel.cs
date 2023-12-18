using Domain.Logic;
using Domain.Models;
using ReactiveTypes;

namespace Features.WeaponsInventory
{
    public class WeaponsInventoryViewModel : BaseViewModel
    {
        public IReactiveProperty<string> CurrentItemID { get; }
        public IReactiveList<string> ItemIDs { get; }

        public WeaponsInventoryViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            CurrentItemID = model.GetProperty<string>(ModelPropertyName.CurrentItemID);
            ItemIDs = model.GetList<string>(ModelListName.ItemIDs);
        }
    }
}