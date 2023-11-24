using UnityEngine;

namespace Repositories.Configs
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Spawn Config", order = 0)]
    public class SpawnConfig : ScriptableObject
    {
        [SerializeField] private float _playerSpawnPositionX;
        [SerializeField] private float _playerSpawnPositionY;
        [SerializeField] private float _enemySpawnBorderOffset;
        [SerializeField] private int _enemiesCount;
    }
}