using System.Collections.Generic;
using UnityEngine;

namespace Services.Factory.GameObjects
{
    public class GameObjectsPoolService : MonoBehaviour, IPoolService<GameObject>
    {
        [SerializeField]
        private Transform _parent;
        
        private readonly IDictionary<string, Stack<GameObject>> _dictionary
            = new Dictionary<string, Stack<GameObject>>();

        public bool TryGet(string key, out GameObject feature)
        {
            if (_dictionary.TryGetValue(key, out Stack<GameObject> gameObjects) && gameObjects.Count > 0)
            {
                feature = gameObjects.Pop();
                feature.SetActive(true);
                return true;
            }

            feature = null;
            return false;
        }

        public void Add(string key, GameObject feature)
        {
            if (!_dictionary.TryGetValue(key, out Stack<GameObject> gameObjects))
            {
                gameObjects = _dictionary[key] = new Stack<GameObject>();
            }
            
            gameObjects.Push(feature);
            feature.transform.parent = _parent;
            feature.SetActive(false);
        }
    }
}