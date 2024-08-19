using System;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    public class DamageableView : MonoBehaviour
    {
        public event Action<float> CollidedWithDamager;
        public void CollideWithDamager(float damage) => CollidedWithDamager?.Invoke(damage);
    }
}