using UnityEngine;

namespace Tanks.Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _weaponViewParent;
        [SerializeField] private SpriteRenderer _healthSpriteRenderer;

        public Transform WeaponViewParent => _weaponViewParent;
        public SpriteRenderer HealthSpriteRenderer => _healthSpriteRenderer;
    }
}