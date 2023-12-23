using Domain.Logic;
using Domain.Models;

namespace Features
{
    public abstract class BaseViewModel
    {
        protected readonly IModel _model;
        protected readonly ILogicCollection _logicCollection;

        protected BaseViewModel(IModel model, ILogicCollection logicCollection)
        {
            _model = model;
            _logicCollection = logicCollection;
        }
    }
}