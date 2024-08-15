using Tanks.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tanks.Bootstrap
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        [SerializeField] private UIViewRoot _uiViewRoot;

        protected override void Configure(IContainerBuilder builder)
        {
            ConfigureUI(builder);
            builder.RegisterEntryPoint<BootstrapSceneStarter>();
        }
        
        private void ConfigureUI(IContainerBuilder builder)
        {
            DontDestroyOnLoad(_uiViewRoot.gameObject);
            builder.RegisterInstance(_uiViewRoot).As<UIViewRoot>().AsSelf();
            builder.Register<UIModel>(Lifetime.Singleton).As<IUIModel>();
            builder.Register<UIService>(Lifetime.Singleton).As<IUIService>();
        }
    }
}