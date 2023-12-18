using Domain.Logic;
using Domain.Models;
using Features;
using Zenject;

namespace Services.Factory.ViewModel
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly DiContainer _diContainer;

        [Inject]
        public ViewModelFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

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
            //viewModel = (TViewModel)Activator.CreateInstance(typeof(TViewModel), model, logicCollection);
            //viewLogic = (TViewLogic)Activator.CreateInstance(typeof(TViewLogic), viewModel, viewFacade);

            viewModel = _diContainer.Instantiate<TViewModel>(new object[]{model, logicCollection});
            viewLogic = _diContainer.Instantiate<TViewLogic>(new object[]{viewModel, viewFacade});
        }
    }
}