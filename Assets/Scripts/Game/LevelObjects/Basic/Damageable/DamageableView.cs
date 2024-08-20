using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public class DamageableView : MonoBehaviour
    {
        public event Action<IDamagerService> CollidedWithDamager;
        public void CollideWithDamager(IDamagerService damagerService) => CollidedWithDamager?.Invoke(damagerService);
    }
}