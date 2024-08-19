using UnityEngine;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public class EnemySpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _enemyViewsParent;

        public Transform EnemyViewsParent => _enemyViewsParent;
    }
}