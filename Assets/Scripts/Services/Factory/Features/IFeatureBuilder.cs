using Configs.Feature;
using Cysharp.Threading.Tasks;
using Domain.Features;

namespace Services.Factory.Features
{
    public interface IFeatureBuilder
    {
        UniTask<IFeature> Build(FeatureConfig featureConfig);
    }
}