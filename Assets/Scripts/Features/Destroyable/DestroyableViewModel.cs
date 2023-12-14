using Domain.Logic;
using Domain.Logic.Destroyable;
using Domain.Models;

namespace Features.Destroyable
{
    public class DestroyableViewModel : BaseViewModel
    {
        private readonly IDestroyableFeatureLogic _destroyableFeatureLogic;

        public DestroyableViewModel(IModel model, ILogicCollection logicCollection) :
            base(model, logicCollection)
        {
            _destroyableFeatureLogic = logicCollection.Get<IDestroyableFeatureLogic>();
        }

        public void Destroy()
        {
            _destroyableFeatureLogic.Destroy();
        }
    }
}