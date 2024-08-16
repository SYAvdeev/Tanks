using UnityEngine;

namespace Tanks.Game.LevelObjects.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        public GameObject GameObject => _gameObject;
    }
}