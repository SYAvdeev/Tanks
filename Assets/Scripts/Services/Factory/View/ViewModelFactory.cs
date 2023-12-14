using System;
using Domain.Logic;
using Domain.Models;
using Features;

namespace Services.Factory.View
{
    public class ViewModelFactory : IViewModelFactory
    {
        public void CreateViewModel<TViewModel, TViewLogic, TViewFacade>(
            IModel model, 
            ILogicCollection logicCollection,
            TViewFacade viewFacade,
            out TViewModel viewModel,
            out TViewLogic viewLogic)
                where TViewModel : BaseViewModel
                where TViewFacade : BaseViewFacade
                where TViewLogic : BaseViewLogic<TViewModel, TViewFacade>
        {
            viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), model, logicCollection);
            viewLogic = (TViewLogic)Activator.CreateInstance(typeof(TViewLogic), viewModel, viewFacade);
        }
    }
}