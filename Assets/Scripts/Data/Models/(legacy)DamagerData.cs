// using System;
// using Domain.Models;
//
// namespace Data.Models
// {
//     [Serializable]
//     public sealed class DamagerData : ModelData
//     {
//         public float Damage;
//
//         private DamagerModel _damagerModel;
//         
//         public DamagerData(DamagerModel damagerModel) : base(damagerModel)
//         {
//             damagerModel.Damage.OnValueChanged += DamageOnOnValueChanged;
//             MapModelToDataAndSetClear();
//         }
//
//         private void DamageOnOnValueChanged(float obj)
//         {
//             MapModelToDataAndSetClear();
//         }
//
//         protected override void MapModelToDataAndSetClear()
//         {
//             Damage = _damagerModel.Damage.Value;
//         }
//     }
// }