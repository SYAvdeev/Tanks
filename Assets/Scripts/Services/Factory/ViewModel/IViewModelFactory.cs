using Domain.Logic;
using Domain.Models;
using Features;

namespace Services.Factory.ViewModel
{
    public interface IViewModelFactory
    {
        TViewModel CreateViewModel<TViewModel>(IModel model, ILogicCollection logicCollection)
            where TViewModel : BaseViewModel;
    }
}