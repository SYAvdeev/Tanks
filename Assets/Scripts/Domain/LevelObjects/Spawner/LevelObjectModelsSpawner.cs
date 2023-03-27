using System;
using System.Collections.Generic;
using Domain.LevelObjects.Config;

namespace Domain.LevelObjects.Spawner
{
    public class LevelObjectModelsSpawner
    {
        private readonly Stack<BulletModel> _bulletsPool = new();
        private readonly Stack<EnemyModel> _enemiesPool = new();
        private readonly BordersRandomPosition _bordersRandomPosition = new();
        private readonly Random _enemiesRandom = new(DateTime.Now.Millisecond);
        private readonly SpawnModelConfig _spawnModelConfig;
        private readonly float _levelAspectRatio;
        private PlayerModel _playerModel;

        public LevelObjectModelsSpawner(SpawnModelConfig spawnModelConfig, float levelAspectRatio)
        {
            _spawnModelConfig = spawnModelConfig;
            _levelAspectRatio = levelAspectRatio;
        }
        
        public PlayerModel SpawnPlayer(PlayerModelConfig playerModelConfig, List<WeaponModelConfig> weaponConfigs)
        {
            if (_playerModel != null)
            {
                _playerModel.Initialize(_spawnModelConfig.PlayerSpawnPositionX, _spawnModelConfig.PlayerSpawnPositionY, 0f);
            }
            else
            {
                _playerModel = new PlayerModel(_spawnModelConfig.PlayerSpawnPositionX, _spawnModelConfig.PlayerSpawnPositionY,
                    0f, _levelAspectRatio, playerModelConfig, weaponConfigs, this);
            }

            return _playerModel;
        }

        public BulletModel SpawnBullet(float positionX, float positionY, float directionAngle, float speed)
        {
            if (!_bulletsPool.TryPop(out BulletModel bullet))
            {
                bullet = new BulletModel(positionX, positionY, directionAngle, speed);
            }
            else
            {
                bullet.Initialize(positionX, positionY, directionAngle, speed);
            }

            return bullet;
        }

        public List<EnemyModel> SpawnEnemiesRandom(List<EnemyModelConfig> enemyConfigs)
        {
            List<EnemyModel> enemies = new List<EnemyModel>();
            for (int i = 0; i < _spawnModelConfig.EnemiesCount; i++)
            {
                enemies.Add(SpawnEnemyRandom(enemyConfigs));
            }

            return enemies;
        }

        public EnemyModel SpawnEnemyRandom(List<EnemyModelConfig> enemyConfigs)
        {
            EnemyModelConfig enemyModelConfig = enemyConfigs[_enemiesRandom.Next(0, enemyConfigs.Count)];
            
            _bordersRandomPosition.GetPosition(out var border, out var position);

            float borderOffset = _spawnModelConfig.EnemySpawnBorderOffset;

            float normalizedPosition = (float)position / BordersRandomPosition.PositionsCount;
            float positionX = border < 2 ? border == 0 ? -_levelAspectRatio - borderOffset : _levelAspectRatio + borderOffset : normalizedPosition;
            float positionY = border < 2 ? normalizedPosition : border == 2 ? -1f - borderOffset : 1f + borderOffset;
            
            if (!_enemiesPool.TryPop(out EnemyModel enemy))
            {
                enemy = new EnemyModel(positionX, positionY, 0f, _playerModel, enemyModelConfig);
            }
            else
            {
                enemy.Initialize(positionX, positionY, enemyModelConfig);
            }

            return enemy;
        }

        public void PushToPool(EnemyModel enemyModel) => PushToPool(enemyModel, _enemiesPool);
        public void PushToPool(BulletModel bulletModel) => PushToPool(bulletModel, _bulletsPool);
        private void PushToPool<T>(T levelObject, Stack<T> pool) where T: LevelObjectModel => pool.Push(levelObject);
    }
}