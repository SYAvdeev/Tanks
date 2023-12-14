namespace Features
{
    public abstract class BaseViewLogic<TViewModel, TViewFacade> 
        where TViewModel : BaseViewModel
        where TViewFacade : BaseViewFacade
    {
        protected TViewModel _viewModel;
        protected TViewFacade _viewFacade;

        protected BaseViewLogic(TViewModel viewModel, TViewFacade viewFacade)
        {
            _viewModel = viewModel;
            _viewFacade = viewFacade;
        }
    }
}