namespace Features
{
    public abstract class BaseViewLogic<TViewModel, TViewFacade> : IViewLogic
        where TViewModel : BaseViewModel
        where TViewFacade : BaseViewFacade
    {
        protected readonly TViewModel _viewModel;
        protected readonly TViewFacade _viewFacade;

        protected BaseViewLogic(TViewModel viewModel, TViewFacade viewFacade)
        {
            _viewModel = viewModel;
            _viewFacade = viewFacade;
        }
    }
}