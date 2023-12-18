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

        public bool TryGet(string key, out GameObject obj)
        {
            if (_dictionary.TryGetValue(key, out Stack<GameObject> gameObjects) && gameObjects.Count > 0)
            {
                obj = gameObjects.Pop();
                obj.SetActive(true);
                return true;
            }

            obj = null;
            return false;
        }

        public void Add(string key, GameObject obj)
        {
            if (!_dictionary.TryGetValue(key, out Stack<GameObject> gameObjects))
            {
                gameObjects = _dictionary[key] = new Stack<GameObject>();
            }
            
            gameObjects.Push(obj);
            obj.transform.parent = _parent;
            obj.SetActive(false);
        }
    }
}