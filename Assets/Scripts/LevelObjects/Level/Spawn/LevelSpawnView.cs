using UnityEngine;

namespace Tanks.LevelObjects.Level.Spawn
{
    public class LevelSpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _levelViewParent;

        public Transform LevelViewParent => _levelViewParent;
    }
}