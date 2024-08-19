using UnityEngine;

namespace Tanks.Game.Spawn.LevelSpawn
{
    public class LevelSpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _levelViewParent;

        public Transform LevelViewParent => _levelViewParent;
    }
}