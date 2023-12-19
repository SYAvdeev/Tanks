using UnityEngine;

namespace Configs
{
    public class SpawnConfig : ScriptableObject
    {
        [SerializeField] private float _playerSpawnPositionX;
        [SerializeField] private float _playerSpawnPositionY;
        [SerializeField] private float _enemySpawnBorderOffset;
        [SerializeField] private int _enemiesCount;
    }
}