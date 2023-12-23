using Configs.Feature;
using Cysharp.Threading.Tasks;
using Features;
using UnityEngine;

namespace Services.Factory.Features
{
    public interface IFeatureBuilder
    {
        UniTask<IFeature> Build(FeatureConfig featureConfig);
        UniTask<IFeature> Build(FeatureConfig featureConfig, Transform viewParent);
    }
}