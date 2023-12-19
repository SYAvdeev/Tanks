using System.Threading.Tasks;
using Features;
using UnityEngine;

namespace Services
{
    public interface ISpawnFeatureService
    {
        Task<IFeature> Create(string id, Transform viewParent);
        void Delete(IFeature feature);
    }
}