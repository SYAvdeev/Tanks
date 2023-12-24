using Cysharp.Threading.Tasks;
using Domain.Logic;

namespace Features.Logic
{
    public interface IInitializableAfterBuildLogic : ILogic
    {
        UniTask Initialize();
    }
}