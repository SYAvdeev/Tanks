namespace Features.WeaponsInventory
{
    public class WeaponsInventoryViewLogic : BaseViewLogic<WeaponsInventoryViewModel, WeaponsInventoryViewFacade>
    {
        public WeaponsInventoryViewLogic(WeaponsInventoryViewModel viewModel, WeaponsInventoryViewFacade viewFacade) : 
            base(viewModel, viewFacade)
        {
        }
    }
}