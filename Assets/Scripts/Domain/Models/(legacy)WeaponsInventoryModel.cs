// using System.Collections.Generic;
// using ReactiveTypes;
//
// namespace Domain.Models
// {
//     public class WeaponsInventoryModel : IModel
//     {
//         public IReactiveProperty<int> CurrentWeaponID { get; }
//         public IReactiveList<int> WeaponIDs { get; }
//
//         public WeaponsInventoryModel(int currentWeaponID, IReadOnlyList<int> weaponIDs)
//         {
//             CurrentWeaponID = new ReactiveProperty<int>(currentWeaponID);
//             WeaponIDs = new ReactiveList<int>(weaponIDs);
//         }
//
//         // public override void SetPosition(float positionX, float positionY)
//         // {
//         //     PositionX = Math.Clamp(positionX, -_maxX, _maxX);
//         //     PositionY = Math.Clamp(positionY, -1f, 1f);
//         //     CallOnPositionUpdate(PositionX, PositionY);
//         // }
//         //
//         // public void StartRotation(bool isClockwise)
//         // {
//         //     _rotateService.IsClockwise = isClockwise;
//         //     _rotateService.IsActive = true;
//         // }
//         //
//         // public void StopRotation()
//         // {
//         //     _rotateService.IsActive = false;
//         // }
//
//         // public void Shoot()
//         // {
//         //     if (!_delayedDeactivateActionService.IsActive)
//         //     {
//         //         DamagerModel damagerModel = _levelObjectModelsSpawner.SpawnBullet(PositionX, PositionY, DirectionAngle, CurrentWeaponModel.BulletSpeed);
//         //         damagerModel.Damage = CurrentWeaponModel.Damage;
//         //         _delayedDeactivateActionService.IsActive = true;
//         //         OnShoot?.Invoke(damagerModel);
//         //     }
//         // }
//     }
// }