using System;
using System.Collections.Generic;
using Configs.Feature;
using Cysharp.Threading.Tasks;
using Data.Models;
using Domain.Features;
using Domain.Logic;
using Domain.Models;
using Features;
using Features.Camera;
using Features.Damageable;
using Features.Damager;
using Features.DelayedDamager;
using Features.Destroyable;
using Features.Level;
using Features.Movable;
using Features.WeaponsInventory;
using Services.Factory.GameObject;
using Services.Factory.Logic;
using Services.Factory.Model;
using Services.Factory.View;
using Services.PrototypeProvider;
using Zenject;

namespace Services.Factory.Features
{
    public class FeatureBuilder : IFeatureBuilder
    {
        private readonly IModelFactory _modelFactory;
        private readonly ILogicFactory _logicFactory;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IPrototypeProvider _prototypeProvider;
        private readonly IGameObjectsFactory _gameObjectsFactory;

        private Feature _currentFeature;

        [Inject]
        public FeatureBuilder(
            IModelFactory modelFactory,
            ILogicFactory logicFactory,
            IViewModelFactory viewModelFactory,
            IPrototypeProvider prototypeProvider,
            IGameObjectsFactory gameObjectsFactory)
        {
            _modelFactory = modelFactory;
            _logicFactory = logicFactory;
            _viewModelFactory = viewModelFactory;
            _prototypeProvider = prototypeProvider;
            _gameObjectsFactory = gameObjectsFactory;
        }

        public async UniTask<IFeature> Build(FeatureConfig featureConfig)
        {
            BuildModel(featureConfig.ID, featureConfig.ModelData);
            BuildLogicCollection(featureConfig.LogicTypes);
            if (!string.IsNullOrEmpty(featureConfig.FeatureRootAssetKey))
            {
                await BuildView(featureConfig.FeatureRootAssetKey);
            }
            return _currentFeature;
        }

        private void BuildModel(string id, IModelData modelData)
        {
            IModel model = _modelFactory.CreateModel(modelData);
            _currentFeature = new Feature(id, model);
        }

        private void BuildLogicCollection(LogicFactoryType[] logicTypes)
        {
            for (int i = 0; i < logicTypes.Length; i++)
            {
                ILogic logic = _logicFactory.CreateLogic(logicTypes[i], _currentFeature);
                _currentFeature.LogicCollection.Add(logic);
            }
        }

        private async UniTask BuildView(string rootAssetKey)
        {
            FeatureViewFacadesRoot featureViewFacadesRootPrefab =
                await _prototypeProvider.Get<FeatureViewFacadesRoot>(rootAssetKey);

            FeatureViewFacadesRoot featureViewFacadesRoot = 
                _gameObjectsFactory.Instantiate(featureViewFacadesRootPrefab.gameObject)
                    .GetComponent<FeatureViewFacadesRoot>();

            _currentFeature.ViewModels = new ViewModelsCollection(featureViewFacadesRoot.ViewFacadeDictionary.Count);
            _currentFeature.ViewsLogic = new ViewLogicCollection(featureViewFacadesRoot.ViewFacadeDictionary.Count);

            foreach (KeyValuePair<ViewType, BaseViewFacade> pair in featureViewFacadesRoot.ViewFacadeDictionary)
            {
                BaseViewFacade viewFacade = pair.Value;

                switch (pair.Key)
                {
                    case ViewType.Camera:
                        CreateView<CameraViewModel, CameraViewFacade, CameraViewLogic>(_currentFeature, viewFacade);
                        break;
                    
                    case ViewType.Damageable:
                        
                        CreateView<DamageableViewModel, DamageableViewFacade, DamageableViewLogic>(_currentFeature, viewFacade);
                        break;
                    
                    case ViewType.Damager:
                        
                        CreateView<DamagerViewModel, DamagerViewFacade, DamagerViewLogic>(_currentFeature, viewFacade);
                        break;
                    
                    case ViewType.DelayedDamager:
                        
                        CreateView<DelayedDamagerViewModel, DelayedDamagerViewFacade, DelayedDamagerViewLogic>(_currentFeature, viewFacade);
                        break;
                    
                    case ViewType.Movable:
                        
                        CreateView<MovableViewModel, MovableViewFacade, MovableViewLogic>(_currentFeature, viewFacade);
                        break;
                    
                    case ViewType.Destroyable:
                        
                        CreateView<DestroyableViewModel, DestroyableViewFacade, DestroyableViewLogic>(_currentFeature, viewFacade);
                        break;
                    
                    case ViewType.WeaponsInventory:
                        
                        CreateView<WeaponsInventoryViewModel, WeaponsInventoryViewFacade, WeaponsInventoryViewLogic>(_currentFeature, viewFacade);
                        break;

                    case ViewType.Level:
                        
                        CreateView<LevelViewModel, LevelViewFacade, LevelViewLogic>(_currentFeature, viewFacade);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void CreateView<TViewModel, TViewFacade, TViewLogic>(Feature feature, BaseViewFacade viewFacade)
            where TViewModel : BaseViewModel
            where TViewFacade : BaseViewFacade
            where TViewLogic : BaseViewLogic<TViewModel, TViewFacade>
        {
            _viewModelFactory.CreateViewModel(
                feature.Model,
                feature.LogicCollection,
                (TViewFacade)viewFacade,
                out TViewModel damageableViewModel,
                out TViewLogic damageableViewLogic);

            feature.ViewModels.Add(damageableViewModel);
            feature.ViewsLogic.Add(damageableViewLogic);
        }
    }
}