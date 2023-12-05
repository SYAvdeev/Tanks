using UnityEngine;

namespace Services
{
    public interface ISpawnService
    {
        GameObject Spawn(string poolKey, string prefabPath, Vector3 position, Transform parent);
        
    }
}