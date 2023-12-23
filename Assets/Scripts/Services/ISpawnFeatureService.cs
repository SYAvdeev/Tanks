using System.Threading.Tasks;
using Features;
using UnityEngine;

namespace Services
{
    public interface ISpawnFeatureService
    {
        Task<IFeature> Create(string id, Transform spawnParent);
        void Delete(IFeature feature);
    }
}