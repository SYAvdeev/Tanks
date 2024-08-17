using UnityEngine;

namespace Tanks.Bullet
{
    public class BulletSpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _bulletViewsParent;

        public Transform BulletViewsParent => _bulletViewsParent;
    }
}