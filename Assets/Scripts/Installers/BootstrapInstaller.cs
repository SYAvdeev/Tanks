using Configs;
using Services.Scenes;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField]
        private ScenesConfig _scenesConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<ScenesConfig>().FromInstance(_scenesConfig);
            Container.Bind<ISceneLoadService>().To<SceneLoadService>().AsSingle();
            Container.Resolve<ISceneLoadService>().LoadGameScene();
        }
    }
}