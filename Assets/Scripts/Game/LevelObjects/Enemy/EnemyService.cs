using System;
using Tanks.Game.LevelObjects.Basic;

namespace Tanks.Enemy
{
    public class EnemyService : IEnemyService
    {
        private readonly IMovableService _movableService;
        private readonly IDamageableService _damageableService;
        private readonly IDamagerService _damagerService;
        
        private readonly IMovableModel _playerMovableModel;
        private readonly IDamageableService _playerDamageableService;

        public IEnemyModel Model { get; }

        public EnemyService(
            IEnemyModel model,
            IMovableModel playerMovableModel,
            IDamageableService playerDamageableService)
        {
            Model = model;
            _playerMovableModel = playerMovableModel;
            _playerDamageableService = playerDamageableService;
            _movableService = new MovableService(model.MovableModel);
            _damageableService = new DamageableService(model.DamageableModel);
            _damagerService = new DamagerService(model.DamagerModel);
        }
        
        public void Update(float deltaTime)
        {
            switch (Model.CurrentState)
            {
                case EnemyState.Move:
                    _movableService.MoveAlongDirection(deltaTime);
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
            
            _movableService.RotateTowards(_playerMovableModel.Position);
        }
    }
}