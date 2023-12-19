using System;
using Domain.Features;
using Domain.Logic;
using Domain.Logic.Camera;
using Domain.Logic.Control;
using Domain.Logic.Damageable;
using Domain.Logic.Damager;
using Domain.Logic.Destroyable;
using Domain.Logic.GameSpawn;
using Domain.Logic.Inventory;
using Domain.Logic.Level;
using Domain.Logic.Tickable;
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

        public ILogic CreateLogic(LogicFactoryType logicType, IFeatureBase featureBase)
        {
            switch (logicType)
            {
                case LogicFactoryType.MovableInputControl:
                    
                    return new MovableInputControlLogic(
                        featureBase.LogicCollection.Get<IMoveLogic>(),
                        featureBase.LogicCollection.Get<IRotateLogic>(), 
                        _container.Resolve<IInputService>());
                
                case LogicFactoryType.ShootInputControl:
                    
                    return new ShootInputControlLogic(
                        _container.Resolve<ITickService>(),
                        _container.Resolve<IInputService>(),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.Delay), 
                        featureBase.Model.GetProperty<float>(ModelPropertyName.CurrentDelay),
                        featureBase.LogicCollection.Get<IGameSpawnLogic>());
                    
                case LogicFactoryType.InventoryInputControl:

                    return new InventoryInputControlLogic(
                        _container.Resolve<IInputService>(),
                        featureBase.LogicCollection.Get<IInventoryLogic>());
                    
                case LogicFactoryType.Damager:

                    return new DamagerLogic(featureBase.Model.GetProperty<float>(ModelPropertyName.Damage));
                
                case LogicFactoryType.DelayedDamage:

                    return new DelayedDamageLogic(
                        _container.Resolve<ITickService>(), 
                        featureBase.Model.GetProperty<float>(ModelPropertyName.Delay), 
                        featureBase.Model.GetProperty<float>(ModelPropertyName.CurrentDelay),
                        featureBase.LogicCollection.Get<IDamagerLogic>());
                    
                case LogicFactoryType.DestroyFeatureOnDie:

                    return new DestroyableFeatureOnDie(
                        featureBase.LogicCollection.Get<IDamageableLogic>(), featureBase);
                
                case LogicFactoryType.Destroyable:
                    
                    return new DestroyableFeatureLogic(featureBase);
                    
                case LogicFactoryType.GameSpawn:
                    
                    return new GameSpawnLogic(
                        _container.Resolve<IStartService>(),
                        featureBase.Model.GetList<string>(ModelListName.RandomEnemiesFeatureIDs),
                        featureBase.Model.GetProperty<string>(ModelPropertyName.SpawnOnShootFeatureID),
                        featureBase.Model.GetProperty<int>(ModelPropertyName.RandomEnemiesSpawnCount),
                        featureBase.LogicCollection.Get<ISpawnOffScreenPositionLogic>(),
                        _container.ResolveId<IFeatureBase>(BindableFeatureType.Player),
                        _container.Resolve<Random>());
                
                case LogicFactoryType.Inventory:

                    return new InventoryLogic(
                        featureBase.Model.GetProperty<string>(ModelPropertyName.CurrentItemID),
                        featureBase.Model.GetList<string>(ModelListName.ItemIDs));
                
                case LogicFactoryType.SpawnOffScreenPosition:

                    IFeatureBase cameraFeatureBase = _container.ResolveId<IFeatureBase>(BindableFeatureType.Camera);
                    return new SpawnOffScreenPositionLogic(
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        cameraFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        _container.Resolve<Random>());
                
                case LogicFactoryType.CameraCharacterMoveRestriction:
                    
                    IFeatureBase levelFeatureBase = _container.ResolveId<IFeatureBase>(BindableFeatureType.Level);
                    return new CameraCharacterMoveRestrictionLogic(
                        featureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY));
                    
                case LogicFactoryType.CharacterMoveRestriction:
                    
                    levelFeatureBase = _container.ResolveId<IFeatureBase>(BindableFeatureType.Level);
                    return new CharacterMoveRestrictionLogic(
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY));
                    
                case LogicFactoryType.LookAtPlayer:
                    
                    IFeatureBase playerFeatureBase = _container.ResolveId<IFeatureBase>(BindableFeatureType.Player);
                    return new LookAtLogic(
                        _container.Resolve<ITickService>(),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.DirectionAngle),
                        playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionY));
                    
                case LogicFactoryType.MoveFollowPlayer:
                    
                    playerFeatureBase = _container.ResolveId<IFeatureBase>(BindableFeatureType.Player);
                    return new MoveFollowLogic(
                        _container.Resolve<ITickService>(),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        featureBase.LogicCollection.Get<IMoveRestrictionLogic>());
                    
                case LogicFactoryType.MoveForward:

                    return new MoveForwardLogic(
                        _container.Resolve<ITickService>(),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.DirectionAngle),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.Speed),
                        featureBase.LogicCollection.Get<IMoveRestrictionLogic>());
                    
                case LogicFactoryType.Rotate:

                    return new RotateLogic(
                        _container.Resolve<ITickService>(),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.RotationSpeed),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.DirectionAngle));
                
                case LogicFactoryType.Damageable:

                    return new DamageableLogic(
                        featureBase.Model.GetProperty<float>(ModelPropertyName.Health),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.Protection));

                case LogicFactoryType.CameraInitializeSize:

                    return new CameraInitializeSizeLogic(
                        _container.Resolve<IStartService>(),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.SizeY));

                case LogicFactoryType.DestroyableTickableUnsubscribe:

                    return new DestroyableTickableUnsubscribeLogic(
                        featureBase.LogicCollection.GetAll<ITickableLogic>(),
                        featureBase.LogicCollection.Get<IDestroyableFeatureLogic>());

                case LogicFactoryType.DestroyableFeatureOutOfLevelBounds:
                    
                    levelFeatureBase = _container.ResolveId<IFeatureBase>(BindableFeatureType.Level);
                    return new DestroyableFeatureOutOfLevelBoundsLogic(
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeX),
                        levelFeatureBase.Model.GetProperty<float>(ModelPropertyName.SizeY),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionX),
                        featureBase.Model.GetProperty<float>(ModelPropertyName.PositionY),
                        featureBase,
                        _container.Resolve<ITickService>());
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(logicType), logicType, null);
            }
        }
        
        
    }
}