using System.Threading.Tasks;
using Features;
using UnityEngine;

namespace Services.Factory.Features
{
    public interface ISpawnFeatureService
    {
        Task<IFeature> Create(string id, Transform viewParent);
        void Delete(IFeature feature);
    }
}