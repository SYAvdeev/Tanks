using Domain.Features;

namespace Domain.Services
{
    public interface ISpawnFeatureService
    {
        void SpawnInitialFeatures();
        IFeature Create(string id);
        void Delete(IFeature feature);
    }
}