using UnityEngine;

namespace Tanks.Game.Spawn.BulletSpawn
{
    public class BulletSpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _bulletViewsParent;

        public Transform BulletViewsParent => _bulletViewsParent;
    }
}