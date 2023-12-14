using Domain.Logic;
using Domain.Models;
using Features;

namespace Services.Factory.View
{
    public interface IViewModelFactory
    {
        void CreateViewModel<TViewModel, TViewLogic, TViewFacade>(
            IModel model,
            ILogicCollection logicCollection,
            TViewFacade viewFacade,
            out TViewModel viewModel,
            out TViewLogic viewLogic)
            where TViewModel : BaseViewModel
            where TViewFacade : BaseViewFacade
            where TViewLogic : BaseViewLogic<TViewModel, TViewFacade>;
    }
}