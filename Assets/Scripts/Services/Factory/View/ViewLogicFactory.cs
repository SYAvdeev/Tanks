using Features;
using Zenject;

namespace Services.Factory.View
{
    public class ViewLogicFactory : IViewLogicFactory
    {
        private readonly DiContainer _diContainer;

        [Inject]
        public ViewLogicFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public TViewLogic CreateViewLogic<TViewModel, TViewLogic, TViewFacade>(
            TViewFacade viewFacade,
            TViewModel viewModel)
            where TViewModel : BaseViewModel
            where TViewFacade : BaseViewFacade
            where TViewLogic : BaseViewLogic<TViewModel, TViewFacade>
        {
            return _diContainer.Instantiate<TViewLogic>(new object[]{viewModel, viewFacade});
        }
    }
}