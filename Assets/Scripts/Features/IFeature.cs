using Domain.Features;
using Services.Factory.ViewModel;

namespace Features
{
    public interface IFeature : IFeatureBase
    {
        public ViewModelsCollection ViewModels { get; }
        public ViewLogicCollection ViewsLogic { get; }
        public FeatureViewRoot ViewRoot { get; }
    }
}