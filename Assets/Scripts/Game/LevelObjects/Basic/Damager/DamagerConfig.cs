using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(DamagerConfig), 
        menuName = "Custom/Game/LevelObjects/Basic/" + nameof(DamagerConfig),
        order = 1)]
    public class DamagerConfig : ConfigBase, IDamagerConfig
    {
        [SerializeField] private float _damage;

        public float Damage => _damage;
    }
}