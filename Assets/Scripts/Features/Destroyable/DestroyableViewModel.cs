using Domain.Logic.Destroyable;
using Domain.Models;

namespace Features.Destroyable
{
    public class DestroyableViewModel : BaseViewModel
    {
        private readonly IDestroyableFeatureLogic _destroyableFeatureLogic;

        public DestroyableViewModel(IModel model, IDestroyableFeatureLogic destroyableFeatureLogic) : base(model)
        {
            _destroyableFeatureLogic = destroyableFeatureLogic;
        }

        public void Destroy()
        {
            _destroyableFeatureLogic.Destroy();
        }
    }
}