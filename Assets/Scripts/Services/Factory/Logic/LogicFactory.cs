using System;
using Domain.Features;
using Domain.Logic;
using Domain.Logic.Camera;
using Domain.Logic.Control;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Logic.Destroyable;
using Domain.Logic.Enemy;
using Domain.Logic.GameSpawn;
using Domain.Logic.Inventory;
using Domain.Logic.Level;
using Domain.Logic.Transformable;
using Domain.Models;
using Domain.Services;
using Domain.Services.Input;
using Services.Factory.Features;
using Zenject;

namespace Services.Factory.Logic
{
    public class LogicFactory : ILogicFactory
    {
        private readonly DiContainer _container;

        [Inject]
        public LogicFactory(DiContainer container)
        {
            _container = container;
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
                    
                    IFeature spawnFeature = _container.ResolveId<IFeature>(BindableFeatureType.Spawn);
                    return new ShootInputControlLogic(
                        _container.Resolve<IInputService>(),
                        spawnFeature.LogicCollection.Get<IGameSpawnLogic>());
                    
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

                    return new DestroyableFeatureLogic(feature, _container.Resolve<ISpawnFeatureService>());
                    
                case LogicFactoryType.GameSpawn:
                    
                    return new GameSpawnLogic(
                        _container.Resolve<IStartService>(),
                        _container.Resolve<ISpawnFeatureService>(),
                        feature.Model.GetList<string>(ModelListName.SpawnOnStartFeatureIDs),
                        feature.Model.GetList<string>(ModelListName.PlayerFeatureIDs),
                        feature.Model.GetList<string>(ModelListName.RandomEnemiesFeatureIDs),
                        feature.Model.GetList<string>(ModelListName.SpawnOnShootFeatureIDs),
                        feature.Model.GetProperty<int>(ModelPropertyName.RandomEnemiesSpawnCount),
                        feature.LogicCollection.Get<ISpawnOffScreenPositionLogic>(),
                        _container.Resolve<Random>());
                
                case LogicFactoryType.Inventory:

                    return new InventoryLogic(
                        feature.Model.GetProperty<int>(ModelPropertyName.CurrentItemID),
                        feature.Model.GetList<int>(ModelListName.ItemIDs));
                
                case LogicFactoryType.SpawnOffScreenPosition:

                    IFeature cameraFeature = _container.ResolveId<IFeature>(BindableFeatureType.Camera);
                    return new SpawnOffScreenPositionLogic(
                        cameraFeature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        cameraFeature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        cameraFeature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        cameraFeature.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        _container.Resolve<Random>());
                
                case LogicFactoryType.CameraCharacterMoveRestriction:
                    
                    IFeature levelFeature = _container.ResolveId<IFeature>(BindableFeatureType.Level);
                    return new CameraCharacterMoveRestrictionLogic(
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        levelFeature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeature.Model.GetProperty<float>(ModelPropertyName.SizeY));
                    
                case LogicFactoryType.CharacterMoveRestriction:
                    
                    levelFeature = _container.ResolveId<IFeature>(BindableFeatureType.Level);
                    return new CharacterMoveRestrictionLogic(
                        levelFeature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeature.Model.GetProperty<float>(ModelPropertyName.SizeY));
                    
                case LogicFactoryType.LookAtPlayer:
                    
                    IFeature playerFeature = _container.ResolveId<IFeature>(BindableFeatureType.Player);
                    return new LookAtLogic(
                        _container.Resolve<ITickService>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        feature.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        feature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle),
                        playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionY));
                    
                case LogicFactoryType.MoveFollowPlayer:
                    
                    playerFeature = _container.ResolveId<IFeature>(BindableFeatureType.Player);
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
                        _container.Resolve<IStartService>(),
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        feature.Model.GetProperty<float>(ModelPropertyName.SizeY));

                case LogicFactoryType.EnemySubscribe:

                    return new EnemySubscribeLogic(
                        feature.LogicCollection.Get<ILookAtLogic>(),
                        feature.LogicCollection.Get<IMoveLogic>(),
                        feature.LogicCollection.Get<IDelayedDamageLogic>(),
                        feature.LogicCollection.Get<IDestroyableFeatureLogic>());
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(logicType), logicType, null);
            }
        }
        
        
    }
}