using Domain.Models;

namespace Features
{
    public class BaseViewModel
    {
        protected IModel _model;

        public BaseViewModel(IModel model)
        {
            _model = model;
        }
    }
}