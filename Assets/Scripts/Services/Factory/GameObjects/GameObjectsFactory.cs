using UnityEngine;

namespace Services.Factory.GameObjects
{
    public class GameObjectsFactory : IGameObjectsFactory
    {
        public GameObject Instantiate(GameObject original) => Object.Instantiate(original);

        public GameObject Instantiate(GameObject original, Transform parent) => Object.Instantiate(original, parent);

        public GameObject Instantiate(
            GameObject original,
            Transform parent,
            bool worldPositionStays) => 
            Object.Instantiate(original, parent, worldPositionStays);

        public GameObject Instantiate(
            GameObject original,
            Vector3 position,
            Quaternion rotation,
            Transform parent = null) =>
            Object.Instantiate(original, position, rotation, parent);

        public void Destroy(GameObject obj)
        {
            Object.Destroy(obj);
        }
    }
}