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

        public TViewModel CreateViewModel<TViewModel>(IModel model, ILogicCollection logicCollection)
                where TViewModel : BaseViewModel
        {
            return _diContainer.Instantiate<TViewModel>(new object[]{model, logicCollection});
        }
    }
}