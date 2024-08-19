using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _weaponViewParent;
        [SerializeField] private SpriteRenderer _healthSpriteRenderer;
        [SerializeField] private DamageableView _damageableView;

        public Transform WeaponViewParent => _weaponViewParent;
        public SpriteRenderer HealthSpriteRenderer => _healthSpriteRenderer;
        public DamageableView DamageableView => _damageableView;
    }
}