using Features;

namespace Services.Factory.View
{
    public interface IViewLogicFactory
    {
        TViewLogic CreateViewLogic<TViewModel, TViewLogic, TViewFacade>(TViewFacade viewFacade, TViewModel viewModel)
            where TViewModel : BaseViewModel
            where TViewFacade : BaseViewFacade
            where TViewLogic : BaseViewLogic<TViewModel, TViewFacade>;
    }
}