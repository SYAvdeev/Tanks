using Domain.LevelObjects.Config;
using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName ="Config", menuName = "Assets/Config/Spawn Config", order = 0)]
    public class SpawnConfig : ScriptableObject
    {
        [SerializeField] private float _playerSpawnPositionX;
        [SerializeField] private float _playerSpawnPositionY;
        [SerializeField] private float _enemySpawnBorderOffset;
        [SerializeField] private int _enemiesCount;
        private SpawnModelConfig _cachedSpawnModelConfig;
        
        public SpawnModelConfig ToSpawnModelConfig() => _cachedSpawnModelConfig ??= 
            new SpawnModelConfig(_playerSpawnPositionX, _playerSpawnPositionY, _enemySpawnBorderOffset, _enemiesCount);
    }
}