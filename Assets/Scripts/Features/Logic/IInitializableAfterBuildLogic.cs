using Domain.Logic;

namespace Features.Logic
{
    public interface IInitializableAfterBuildLogic : ILogic
    {
        void Initialize();
    }
}