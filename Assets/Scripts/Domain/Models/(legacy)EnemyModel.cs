// using Domain.Model.Behaviour;
// using Domain.Model.Config;
// using Domain.Services;
// using Domain.Services.Damageable;
// using Domain.Services.Damager;
// using Domain.Services.Transformable;
//
// namespace Domain.Model
// {
//     public class EnemyModel : DamageableModel
//     {
//         private readonly LookAtService _lookAtService;
//         private readonly DelayedDamageActionService _delayedDamageActionService;
//         
//         public EnemyModelConfig Config => (EnemyModelConfig)_characterModelConfig;
//
//         public EnemyModel(float positionX, float positionY, float directionAngle, DamageableModel target, EnemyModelConfig enemyModelConfig) : base(positionX, positionY, directionAngle, enemyModelConfig)
//         {
//             _lookAtService = new LookAtService(this, target);
//             _delayedDamageActionService = new DelayedDamageActionService(Config.Damage, Config.AttackDelay, target);
//
//             _currentBehaviours.Add(_lookAtService);
//             _currentBehaviours.Add(_delayedDamageActionService);
//             
//             _lookAtService.IsActive = true;
//             _moveBehaviour.IsActive = true;
//         }
//
//         public void Initialize(float positionX, float positionY, EnemyModelConfig enemyModelConfig)
//         {
//             _characterModelConfig = enemyModelConfig;
//             SetPosition(positionX, positionY);
//             _delayedDamageActionService.SetParameters(enemyModelConfig.Damage, enemyModelConfig.AttackDelay);
//             _moveBehaviour.SetSpeed(enemyModelConfig.Speed);
//             OnRotationUpdate += _moveBehaviour.OnRotationUpdate;
//             Health = MaxHealth;
//             
//             _lookAtService.IsActive = true;
//             _moveBehaviour.IsActive = true;
//         }
//
//         public void SetAttack(bool isActive)
//         {
//             SetMove(!isActive);
//             _delayedDamageActionService.IsActive = isActive;
//
//             if (isActive)
//             {
//                 _delayedDamageActionService.Delay = 0f;
//             }
//         }
//     }
// }