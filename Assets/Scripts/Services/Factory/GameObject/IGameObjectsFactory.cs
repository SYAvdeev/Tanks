using UnityEngine;

namespace Services.Factory.GameObject
{
    public interface IGameObjectsFactory
    {
        UnityEngine.GameObject Instantiate(UnityEngine.GameObject original);
        UnityEngine.GameObject Instantiate(UnityEngine.GameObject original, Transform parent);
        UnityEngine.GameObject Instantiate(UnityEngine.GameObject original, Transform parent, bool worldPositionStays);
        UnityEngine.GameObject Instantiate(UnityEngine.GameObject original, Vector3 position, Quaternion rotation, Transform parent = null);
        void Destroy(UnityEngine.GameObject obj);
    }
}