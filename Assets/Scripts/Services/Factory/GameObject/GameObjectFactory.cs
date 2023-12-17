using UnityEngine;

namespace Services.Factory.GameObject
{
    public class GameObjectsFactory : IGameObjectsFactory
    {
        public UnityEngine.GameObject Instantiate(UnityEngine.GameObject original) => Object.Instantiate(original);

        public UnityEngine.GameObject Instantiate(UnityEngine.GameObject original, Transform parent) => Object.Instantiate(original, parent);

        public UnityEngine.GameObject Instantiate(
            UnityEngine.GameObject original,
            Transform parent,
            bool worldPositionStays) => 
            Object.Instantiate(original, parent, worldPositionStays);

        public UnityEngine.GameObject Instantiate(
            UnityEngine.GameObject original,
            Vector3 position,
            Quaternion rotation,
            Transform parent = null) =>
            Object.Instantiate(original, position, rotation, parent);

        public void Destroy(UnityEngine.GameObject obj)
        {
            Object.Destroy(obj);
        }
    }
}