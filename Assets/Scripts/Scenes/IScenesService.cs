using Cysharp.Threading.Tasks;

namespace Tanks.Scenes
{
    public interface IScenesService
    {
        UniTask LoadScene(int sceneIndex, bool unloadCurrentScene = true);
        UniTask LoadGameScene(bool unloadCurrentScene = true);
    }
}