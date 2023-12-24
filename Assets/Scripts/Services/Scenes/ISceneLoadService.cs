using Cysharp.Threading.Tasks;

namespace Services.Scenes
{
    public interface ISceneLoadService
    {
        UniTask LoadGameScene();
    }
}