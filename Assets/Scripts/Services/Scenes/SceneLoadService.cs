
using Configs;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Services.Scenes
{
    public class SceneLoadService : ISceneLoadService
    {
        private ScenesConfig _scenesConfig;
        private ZenjectSceneLoader _zenjectSceneLoader;

        [Inject]
        public SceneLoadService(ScenesConfig scenesConfig, ZenjectSceneLoader zenjectSceneLoader)
        {
            _scenesConfig = scenesConfig;
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public async UniTask LoadGameScene()
        {
            await _zenjectSceneLoader.LoadSceneAsync(_scenesConfig.GameSceneIndex);
        }
    }
}