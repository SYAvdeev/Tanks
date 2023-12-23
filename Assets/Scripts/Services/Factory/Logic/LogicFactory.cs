using System;
using Configs.Feature;
using Domain.Features;
using Domain.Logic;
using Domain.Logic.Camera;
using Domain.Logic.Control;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Logic.Destroyable;
using Domain.Logic.Inventory;
using Domain.Logic.Level;
using Domain.Logic.Tickable;
using Domain.Logic.Transformable;
using Domain.Models;
using Domain.Services;
using Domain.Services.Input;
using Features;
using Features.Logic.Camera;
using Features.Logic.Control;
using Features.Logic.Damageable;
using Features.Logic.Damager;
using Features.Logic.Destroyable;
using Features.Logic.GameSpawn;
using Features.Logic.Inventory;
using Zenject;

namespace Services.Factory.Logic
{
    public class LogicFactory : ILogicFactory
    {
        private readonly DiContainer _container;
        private readonly FeaturesConfig _featuresConfig;
        private readonly IUniqueFeaturesContainer _uniqueFeaturesContainer;

        [Inject]
        public LogicFactory(
            DiContainer container,
            FeaturesConfig featuresConfig,
            IUniqueFeaturesContainer uniqueFeaturesContainer)
        {
            _container = container;
            _featuresConfig = featuresConfig;
            _uniqueFeaturesContainer = uniqueFeaturesContainer;
        }

        public ILogic CreateLogic(LogicFactoryType logicType, IFeature feature)
        {
            switch (logicType)
            {
                case LogicFactoryType.MovableInputControl:
                    
                    return new MovableInputControlLogic(
                        feature.LogicCollection.Get<IMoveLogic>(),
                        feature.LogicCollection.Get<IRotateLogic>(), 
                        _container.Resolve<IInputService>());
                
                case LogicFactoryType.ShootInputControl:
                    
                    IFeatureBase playerFeature = _uniqueFeaturesContainer.GetFeature(_featuresConfig.PlayerFeatureID);
                    return new ShootInputControlLogic(
                        _container.Resolve<ITickService>(),
                        _container.Resolve<IInputService>(),
                        _container.Resolve<IUniqueFeaturesContainer>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.Delay), 
                        feature.Model.GetProperty<float>(ModelPropertyName.CurrentDelay),
                        playerFeature.Model.GetProperty<string>(ModelPropertyName.CurrentItemID),
                        feature.LogicCollection.Get<IGameSpawnLogic>(),
                        playerFeature.LogicCollection.Get<IInventorySpawnLogic>());
                    
                case LogicFactoryType.InventoryInputControl:

                    return new InventoryInputControlLogic(
                        _container.Resolve<IInputService>(),
                        feature.LogicCollection.Get<IInventoryLogic>());
                    
                case LogicFactoryType.Damager:

                    return new DamagerLogic(feature.Model.GetProperty<float>(ModelPropertyName.Damage));
                
                case LogicFactoryType.DelayedDamage:

                    return new DelayedDamageLogic(
                        _container.Resolve<ITickService>(), 
                        feature.Model.GetProperty<float>(ModelPropertyName.Delay), 
                        feature.Model.GetProperty<float>(ModelPropertyName.CurrentDelay),
                        feature.LogicCollection.Get<IDamagerLogic>());
                    
                case LogicFactoryType.DestroyFeatureOnDie:

                    return new DestroyableFeatureOnDie(
                        feature.LogicCollection.Get<IDamageableLogic>(), feature);
                
                case LogicFactoryType.Destroyable:
                    
                    return new DestroyableFeatureLogic(feature);
                    
                case LogicFactoryType.GameSpawn:
                    
                    playerFeature = _uniqueFeaturesContainer.GetFeature(_featuresConfig.PlayerFeatureID);
                    return new GameSpawnLogic(
                        _container.Resolve<IStartService>(),
                        _container.Resolve<ISpawnFeatureService>(),
                        _container.Resolve<IUniqueFeaturesContainer>(),
                        feature.Model.GetList<string>(ModelListName.RandomEnemiesFeatureIDs),
                        feature.Model.GetProperty<string>(ModelPropertyName.SpawnOnShootFeatureID),
                        feature.Model.GetProperty<int>(ModelPropertyName.RandomEnemiesSpawnCount),
                        feature.LogicCollection.Get<ISpawnOffScreenPositionLogic>(),
                        playerFeature,
                        _container.Resolve<Random>(),
                        feature);
                
                case LogicFactoryType.Inventory:

                    return new InventoryLogic(
                        feature.Model.GetProperty<string>(ModelPropertyName.CurrentItemID),
                        feature.Model.GetList<string>(ModelListName.ItemIDs));
                
                case LogicFactoryType.SpawnOffScreenPosition:

                    IFeatureBase cameraFeatureBase = _uniqueFeaturesContainer.GetFeature(_featuresConfig.CameraFeatureID);
                    return new SpawnOffScreenPositionLogic(
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        _container.Resolve<Random>());
                
                case LogicFactoryType.CameraCharacterMoveRestriction:
                    
                    IFeatureBase levelFeatureBase = _uniqueFeaturesContainer.GetFeature(_featuresConfig.LevelFeatureID);
                    return new CameraCharacterMoveRestrictionLogic(
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY));
                    
                case LogicFactoryType.CharacterMoveRestriction:
                    
                    levelFeatureBase = _uniqueFeaturesContainer.GetFeature(_featuresConfig.LevelFeatureID);
                    return new CharacterMoveRestrictionLogic(
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY));
                    
                case LogicFactoryType.LookAtPlayer:
                    
                    playerFeature = _uniqueFeaturesContainer.GetFeature(_featuresConfig.PlayerFeatureID);
                    return new LookAtLogic(
                        _container.Resolve<ITickService>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        feature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle),
                        playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionY));
                    
                case LogicFactoryType.MoveFollowPlayer:
                    
                    playerFeature = _uniqueFeaturesContainer.GetFeature(_featuresConfig.PlayerFeatureID);
                    return new MoveFollowLogic(
                        _container.Resolve<ITickService>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        feature.LogicCollection.Get<IMoveRestrictionLogic>());
                    
                case LogicFactoryType.MoveForward:

                    return new MoveForwardLogic(
                        _container.Resolve<ITickService>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        feature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle),
                        feature.Model.GetProperty<float>(ModelPropertyName.Speed),
                        feature.LogicCollection.Get<IMoveRestrictionLogic>());
                    
                case LogicFactoryType.Rotate:

                    return new RotateLogic(
                        _container.Resolve<ITickService>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.RotationSpeed),
                        feature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle));
                
                case LogicFactoryType.Damageable:

                    return new DamageableLogic(
                        feature.Model.GetProperty<float>(ModelPropertyName.Health),
                        feature.Model.GetProperty<float>(ModelPropertyName.Protection));

                case LogicFactoryType.CameraInitializeSize:

                    return new CameraInitializeSizeLogic(
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        feature);

                case LogicFactoryType.DestroyableTickableUnsubscribe:

                    return new DestroyableTickableUnsubscribeLogic(
                        feature.LogicCollection.GetAll<ITickableLogic>(),
                        feature.LogicCollection.Get<IDestroyableFeatureLogic>());

                case LogicFactoryType.DestroyableFeatureOutOfLevelBounds:
                    
                    levelFeatureBase = _uniqueFeaturesContainer.GetFeature(_featuresConfig.LevelFeatureID);
                    return new DestroyableFeatureOutOfLevelBoundsLogic(
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        feature,
                        _container.Resolve<ITickService>());

                case LogicFactoryType.DamageablePhysicsInitialize:

                    return new DamageablePhysicsInitializeLogic(feature.LogicCollection.Get<IDamageableLogic>(), feature);
                
                case LogicFactoryType.DamageOnCollision:

                    return new DamageOnCollisionLogic(feature, feature.LogicCollection.Get<IDamagerLogic>());
                    
                case LogicFactoryType.DestroyOnCollision:
                    
                    return new DestroyOnCollisionLogic(feature.LogicCollection.Get<IDestroyableFeatureLogic>(), feature);
                    
                case LogicFactoryType.InventorySpawn:

                    return new InventorySpawnLogic(
                        feature.Model.GetList<string>(ModelListName.ItemIDs),
                        _container.Resolve<ISpawnFeatureService>(),
                        _uniqueFeaturesContainer,
                        feature);

                case LogicFactoryType.DelayedDamageOnCollision:

                    return new DelayedDamageOnCollisionLogic(
                        feature.LogicCollection.Get<IDelayedDamageLogic>(),
                        feature.LogicCollection.Get<IMoveLogic>(),
                        feature);
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(logicType), logicType, null);
            }
        }
        
        
    }
}