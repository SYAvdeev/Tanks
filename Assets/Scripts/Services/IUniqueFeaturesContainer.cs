using Features;

namespace Services
{
    public interface IUniqueFeaturesContainer
    {
        IFeature GetFeature(string featureID);
        void Add(IFeature featureBase);
    }
}