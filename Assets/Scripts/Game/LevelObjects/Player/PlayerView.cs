using Tanks.Game.LevelObjects.Basic;
using UnityEngine;

namespace Tanks.Game.LevelObjects.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _weaponViewParent;
        [SerializeField] private Transform _rotateTransform;
        [SerializeField] private SpriteRenderer _healthSpriteRenderer;
        [SerializeField] private DamageableView _damageableView;
        [SerializeField] private float _healthBarMaxWidth;

        public Transform WeaponViewParent => _weaponViewParent;
        public Transform RotateTransform => _rotateTransform;
        public SpriteRenderer HealthSpriteRenderer => _healthSpriteRenderer;
        public DamageableView DamageableView => _damageableView;
        public float HealthBarMaxWidth => _healthBarMaxWidth;
    }
}