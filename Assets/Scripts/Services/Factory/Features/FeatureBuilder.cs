using System;
using System.Collections.Generic;
using Configs.Feature;
using Cysharp.Threading.Tasks;
using Data.Models;
using Domain.Logic;
using Domain.Models;
using Features;
using Features.Damageable;
using Features.Movable;
using Features.Inventory;
using Features.Logic;
using Services.Factory.Logic;
using Services.Factory.Model;
using Services.Factory.View;
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
        private readonly IViewLogicFactory _viewLogicFactory;
        private readonly IAssetsSpawnService _assetsSpawnService;

        [Inject]
        public FeatureBuilder(
            IModelFactory modelFactory,
            ILogicFactory logicFactory,
            IViewModelFactory viewModelFactory,
            IViewLogicFactory viewLogicFactory,
            IAssetsSpawnService assetsSpawnService)
        {
            _modelFactory = modelFactory;
            _logicFactory = logicFactory;
            _viewModelFactory = viewModelFactory;
            _viewLogicFactory = viewLogicFactory;
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

            foreach (IInitializableAfterBuildLogic initializeLogic in feature.LogicCollection.GetAll<IInitializableAfterBuildLogic>())
            {
                await initializeLogic.Initialize();
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
                    case ViewType.Damageable:

                        DamageableViewModel damageableViewModel = CreateViewModel<DamageableViewModel>(feature);
                        CreateView<DamageableViewModel, DamageableViewFacade, DamageableViewLogic>(feature, viewFacade, damageableViewModel);
                        break;
                    
                    case ViewType.Movable:
                        
                        MovableViewModel movableViewModel = CreateViewModel<MovableViewModel>(feature);
                        CreateView<MovableViewModel, MovableViewFacade, MovableViewLogic>(feature, viewFacade, movableViewModel);
                        break;
                    
                    case ViewType.Inventory:
                        
                        InventoryViewModel inventoryViewModel = CreateViewModel<InventoryViewModel>(feature);
                        CreateView<InventoryViewModel, InventoryViewFacade, InventoryViewLogic>(feature, viewFacade, inventoryViewModel);
                        break;
                }
            }
        }

        private TViewModel CreateViewModel<TViewModel>(IFeature feature) where TViewModel : BaseViewModel
        {
            TViewModel damageableViewModel = 
                _viewModelFactory.CreateViewModel<TViewModel>(feature.Model, feature.LogicCollection);

            feature.ViewModels.Add(damageableViewModel);

            return damageableViewModel;
        }

        private void CreateView<TViewModel, TViewFacade, TViewLogic>(
            IFeature feature, 
            BaseViewFacade viewFacade, 
            TViewModel viewModel)
            where TViewModel : BaseViewModel
            where TViewFacade : BaseViewFacade
            where TViewLogic : BaseViewLogic<TViewModel, TViewFacade>
        {
            TViewLogic viewLogic =
                _viewLogicFactory.CreateViewLogic<TViewModel, TViewLogic, TViewFacade>((TViewFacade)viewFacade, viewModel);
            feature.ViewsLogic.Add(viewLogic);
        }
    }
}