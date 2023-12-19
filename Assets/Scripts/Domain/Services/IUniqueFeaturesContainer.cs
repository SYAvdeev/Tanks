using Domain.Features;

namespace Domain.Services
{
    public interface IUniqueFeaturesContainer
    {
        IFeatureBase GetFeature(string featureID);
        void Add(IFeatureBase featureBase);
    }
}