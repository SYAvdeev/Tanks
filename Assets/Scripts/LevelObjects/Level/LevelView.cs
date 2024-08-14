using UnityEngine;

namespace Tanks.LevelObjects.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        public GameObject GameObject => _gameObject;
    }
}