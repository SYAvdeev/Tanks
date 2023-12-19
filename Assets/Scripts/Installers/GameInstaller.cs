using System.Threading.Tasks;
using Configs.Feature;
using Configs.Prototype;
using Domain.Features;
using Domain.Services;
using Domain.Services.Input;
using Features;
using Services;
using Services.Factory.Features;
using Services.Factory.GameObjects;
using Services.Factory.Logic;
using Services.Factory.Model;
using Services.Factory.ViewModel;
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
        [SerializeField]
        private GameObjectsPoolService _gameObjectsPoolService;

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
            IFeatureBuilder featureBuilder = Container.Resolve<IFeatureBuilder>();
            IUniqueFeaturesContainer uniqueFeaturesContainer = Container.Resolve<IUniqueFeaturesContainer>();
            
            for (int i = 0; i < _featuresConfig.UniqueFeatureConfigsCreateOrder.Length; i++)
            {
                string featureID = _featuresConfig.UniqueFeatureConfigsCreateOrder[i];
                FeatureConfig featureConfig = _featuresConfig.UniqueFeatureConfigs[featureID];
                IFeatureBase featureBase = await featureBuilder.Build(featureConfig);
                uniqueFeaturesContainer.Add(featureBase);
            }
        }

        private void BindFactories()
        {
            Container.Bind<IModelFactory>().To<ModelFactory>().AsSingle();
            Container.Bind<ILogicFactory>().To<LogicFactory>().AsSingle();
            Container.Bind<IViewModelFactory>().To<ViewModelFactory>().AsSingle();
            Container.Bind<IGameObjectsFactory>().To<GameObjectsFactory>().AsSingle();
            Container.Bind<IPrototypeProvider>().To<AddressablesPrototypeProvider>().AsSingle();
            Container.Bind<IPoolService<GameObject>>().FromInstance(_gameObjectsPoolService).AsSingle();
            Container.Bind<IAssetsSpawnService>().To<AssetsSpawnService>().AsSingle();
            Container.Bind<IFeatureBuilder>().To<FeatureBuilder>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<IUniqueFeaturesContainer>().To<UniqueFeatureContainer>().AsSingle();
            Container.Bind<IInputService>().FromInstance(_inputService);
            Container.Bind<IStartService>().FromInstance(_tickableService);
            Container.Bind<ITickService>().FromInstance(_tickableService);
            Container.Bind<IPoolService<IFeature>>().To<FeaturesPoolService>().AsSingle();
            Container.Bind<ISpawnFeatureService>().To<SpawnFeatureService>().AsSingle();
        }
    }
}