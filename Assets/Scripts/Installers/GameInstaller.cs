using System.Threading.Tasks;
using Configs.Feature;
using Configs.Prototype;
using Domain.Features;
using Domain.Services;
using Domain.Services.Input;
using Services;
using Services.Factory.Features;
using Services.Factory.GameObject;
using Services.Factory.Logic;
using Services.Factory.Model;
using Services.Factory.View;
using Services.PrototypeProvider;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Configs")]
        [SerializeField]
        private FeaturesConfig _featuresConfig;
        [SerializeField]
        private AddressablesPrototypesConfig _prototypesConfig;
        
        [Header("Services")]
        [SerializeField]
        private InputService _inputService;
        [SerializeField]
        private TickableService _tickableService;

        public override async void InstallBindings()
        {
            Container.Bind<System.Random>().To<System.Random>().AsSingle();
            BindConfigs();
            BindFactories();
            BindServices();
            await BindFeatures();
            _tickableService.StartTicks();
        }

        private void BindConfigs()
        {
            Container.Bind<FeaturesConfig>().FromInstance(_featuresConfig);
            Container.Bind<AddressablesPrototypesConfig>().FromInstance(_prototypesConfig);
        }

        private async Task BindFeatures()
        {
            for (int i = 0; i < _featuresConfig.BindableFeatureConfigs.Length; i++)
            {
                BindableFeatureConfig bindableFeatureConfig = _featuresConfig.BindableFeatureConfigs[i];
                FeatureConfig featureConfig = _featuresConfig.AllFeatureConfigs[bindableFeatureConfig.FeatureID];
                IFeatureBuilder featureBuilder = Container.Resolve<IFeatureBuilder>();
                IFeature feature = await featureBuilder.Build(featureConfig);
                Container.Bind<IFeature>().WithId(bindableFeatureConfig.BindableFeatureType).FromInstance(feature);
            }
        }

        private void BindFactories()
        {
            Container.Bind<IModelFactory>().To<ModelFactory>().AsSingle();
            Container.Bind<ILogicFactory>().To<LogicFactory>().AsSingle();
            Container.Bind<IViewModelFactory>().To<ViewModelFactory>().AsSingle();
            Container.Bind<IGameObjectsFactory>().To<GameObjectsFactory>().AsSingle();
            Container.Bind<IPrototypeProvider>().To<AddressablesPrototypeProvider>().AsSingle();
            Container.Bind<IFeatureBuilder>().To<FeatureBuilder>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IInputService>().FromInstance(_inputService);
            Container.Bind<IStartService>().FromInstance(_tickableService);
            Container.Bind<ITickService>().FromInstance(_tickableService);
            Container.Bind<IPoolService<IFeature>>().To<FeaturesPoolService>().AsSingle();
            Container.Bind<ISpawnFeatureService>().To<SpawnFeatureService>().AsSingle();
        }
    }
}