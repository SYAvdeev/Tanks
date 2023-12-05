using UnityEngine;

namespace Features.Poolable
{
    public class PoolableViewFacade : MonoBehaviour
    {
        [SerializeField]
        private GameObject _pooledObject;

        public GameObject PooledObject => _pooledObject;
    }
}