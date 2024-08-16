using Tanks.Utility;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Basic
{
    [CreateAssetMenu(
        fileName = nameof(DamageableConfig), 
        menuName = "Custom/Game/LevelObjects/Basic/" + nameof(DamageableConfig),
        order = 0)]
    public class DamageableConfig : ConfigBase, IDamageableConfig
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] [Range(0f, 1f)] private float _protection;

        public float MaxHealth => _maxHealth;
        public float Protection => _protection;
    }
}