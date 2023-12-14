using System.Threading.Tasks;
using Domain.Features;

namespace Domain.Services
{
    public interface ISpawnFeatureService
    {
        Task<IFeature> Create(string id);
        void Delete(IFeature feature);
    }
}