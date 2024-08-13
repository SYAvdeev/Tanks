using Tanks.Utility;
using UnityEngine;

namespace Tanks.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(DamagerConfig), 
        menuName = "Custom/LevelObjects/Basic/" + nameof(DamagerConfig),
        order = 1)]
    public class DamagerConfig : ConfigBase, IDamagerConfig
    {
        [SerializeField] private float _damage;

        public float Damage => _damage;
    }
}