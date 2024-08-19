﻿using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Game.LevelObjects.Enemy
{
    public class EnemyService : IEnemyService
    {
        private readonly IDamagerService _damagerService;
        private readonly IMovableModel _playerMovableModel;
        private readonly IDamageableService _playerDamageableService;

        public IEnemyModel Model { get; }
        public IMovableService MovableService { get; }
        public IDamageableService DamageableService { get; }

        public EnemyService(
            IEnemyModel model,
            IMovableModel playerMovableModel,
            IDamageableService playerDamageableService)
        {
            Model = model;
            _playerMovableModel = playerMovableModel;
            _playerDamageableService = playerDamageableService;
            MovableService = new MovableService(model.Movable);
            DamageableService = new DamageableService(model.Damageable);
            _damagerService = new DamagerService(model.Damager);
        }
        
        public void Update(float deltaTime)
        {
            switch (Model.CurrentState)
            {
                case EnemyState.Move:
                    MovableService.MoveAlongDirection(deltaTime);
                    break;
                case EnemyState.Attack:
                    if (Model.CurrentAttackCooldown > 0f)
                    {
                        Model.SetCurrentAttackCooldown(Model.CurrentAttackCooldown - deltaTime);
                    }
                    else
                    {
                        _damagerService.MakeDamage(_playerDamageableService);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            MovableService.RotateTowards(_playerMovableModel.Position);
        }
    }
}