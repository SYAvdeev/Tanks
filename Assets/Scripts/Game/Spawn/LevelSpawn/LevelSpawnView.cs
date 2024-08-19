using UnityEngine;

namespace Tanks.Game.LevelObjects.Level
{
    public class LevelSpawnView : MonoBehaviour
    {
        [SerializeField] private Transform _levelViewParent;

        public Transform LevelViewParent => _levelViewParent;
    }
}