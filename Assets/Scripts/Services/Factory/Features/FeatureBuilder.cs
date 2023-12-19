using System;
using System.Collections.Generic;
using Configs.Feature;
using Cysharp.Threading.Tasks;
using Data.Models;
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
using Features.Spawn;
using Features.WeaponsInventory;
using Services.Factory.Logic;
using Services.Factory.Model;
using Services.Factory.ViewModel;
using Services.PrototypeProvider;
using UnityEngine;
using Zenject;

namespace Services.Factory.Features
{
    public class FeatureBuilder : IFeatureBuilder
    {
        private readonly IModelFactory _modelFactory;
        private readonly ILogicFactory _logicFactory;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IAssetsSpawnService _assetsSpawnService;

        //private Feature _currentFeature;

        [Inject]
        public FeatureBuilder(
            IModelFactory modelFactory,
            ILogicFactory logicFactory,
            IViewModelFactory viewModelFactory,
            IAssetsSpawnService assetsSpawnService)
        {
            _modelFactory = modelFactory;
            _logicFactory = logicFactory;
            _viewModelFactory = viewModelFactory;
            _assetsSpawnService = assetsSpawnService;
        }

        public async UniTask<IFeature> Build(FeatureConfig featureConfig)
        {
            return await BuildInternal(
                featureConfig, 
                () => _assetsSpawnService.Spawn<FeatureViewRoot>(featureConfig.FeatureRootAssetKey));
        }

        public async UniTask<IFeature> Build(FeatureConfig featureConfig, Transform viewParent)
        {
            return await BuildInternal(
                featureConfig, 
                () => _assetsSpawnService.Spawn<FeatureViewRoot>(featureConfig.FeatureRootAssetKey, viewParent));
        }
        
        private async UniTask<IFeature> BuildInternal(FeatureConfig featureConfig, Func<UniTask<FeatureViewRoot>> spawnFunction)
        {
            Feature feature = BuildModel(featureConfig.ID, featureConfig.ModelData);
            BuildLogicCollection(featureConfig.LogicTypes, feature);
            
            string featureRootAssetKey = featureConfig.FeatureRootAssetKey;
            if (!string.IsNullOrEmpty(featureRootAssetKey))
            {
                FeatureViewRoot featureViewRoot = await spawnFunction();
                BuildView(featureViewRoot, feature);
            }
            return feature;
        }

        private Feature BuildModel(string id, IModelData modelData)
        {
            IModel model = _modelFactory.CreateModel(modelData);
            return new Feature(id, model);
        }

        private void BuildLogicCollection(LogicFactoryType[] logicTypes, Feature feature)
        {
            for (int i = 0; i < logicTypes.Length; i++)
            {
                ILogic logic = _logicFactory.CreateLogic(logicTypes[i], feature);
                feature.LogicCollection.Add(logic);
            }
        }

        private void BuildView(FeatureViewRoot featureViewRoot, Feature feature)
        {
            feature.ViewRoot = featureViewRoot;
            feature.ViewModels = new ViewModelsCollection(featureViewRoot.ViewFacadeDictionary.Count);
            feature.ViewsLogic = new ViewLogicCollection(featureViewRoot.ViewFacadeDictionary.Count);

            foreach (KeyValuePair<ViewType, BaseViewFacade> pair in featureViewRoot.ViewFacadeDictionary)
            {
                BaseViewFacade viewFacade = pair.Value;

                switch (pair.Key)
                {
                    case ViewType.Camera:
                        CreateView<CameraViewModel, CameraViewFacade, CameraViewLogic>(feature, viewFacade);
                        break;
                    
                    case ViewType.Damageable:
                        
                        CreateView<DamageableViewModel, DamageableViewFacade, DamageableViewLogic>(feature, viewFacade);
                        break;
                    
                    case ViewType.Damager:
                        
                        CreateView<DamagerViewModel, DamagerViewFacade, DamagerViewLogic>(feature, viewFacade);
                        break;
                    
                    case ViewType.DelayedDamager:
                        
                        CreateView<DelayedDamagerViewModel, DelayedDamagerViewFacade, DelayedDamagerViewLogic>(feature, viewFacade);
                        break;
                    
                    case ViewType.Movable:
                        
                        CreateView<MovableViewModel, MovableViewFacade, MovableViewLogic>(feature, viewFacade);
                        break;
                    
                    case ViewType.Destroyable:
                        
                        CreateView<DestroyableViewModel, DestroyableViewFacade, DestroyableViewLogic>(feature, viewFacade);
                        break;
                    
                    case ViewType.WeaponsInventory:
                        
                        CreateView<WeaponsInventoryViewModel, WeaponsInventoryViewFacade, WeaponsInventoryViewLogic>(feature, viewFacade);
                        break;

                    case ViewType.Level:
                        
                        CreateView<LevelViewModel, LevelViewFacade, LevelViewLogic>(feature, viewFacade);
                        break;

                    case ViewType.Spawn:
                        CreateView<SpawnViewModel, SpawnViewFacade, SpawnViewLogic>(feature, viewFacade);
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