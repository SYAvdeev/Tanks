using Domain.Models;

namespace Features
{
    public abstract class BaseViewModel
    {
        protected readonly IModel _model;

        protected BaseViewModel(IModel model)
        {
            _model = model;
        }
    }
}