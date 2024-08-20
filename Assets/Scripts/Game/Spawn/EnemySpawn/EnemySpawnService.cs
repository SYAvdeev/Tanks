using System;
using System.Linq;
using Tanks.Game.LevelObjects.Camera;
using Tanks.Game.LevelObjects.Enemy;
using Tanks.Game.LevelObjects.Player;
using Tanks.Utility.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tanks.Game.Spawn.EnemySpawn
{
    public class EnemySpawnService : IEnemySpawnService
    {
        private readonly IPlayerService _playerService;
        private readonly ICameraService _cameraService;
        public IEnemySpawnModel Model { get; }

        public EnemySpawnService(
            IEnemySpawnModel model,
            IPlayerService playerService, 
            ICameraService cameraService)
        {
            Model = model;
            _playerService = playerService;
            _cameraService = cameraService;
        }

        private void SpawnRandomEnemy()
        {
            var randomEnemyConfig = Model.Config.EnemyConfigs.ToList().Random();
            if(!Model.EnemiesPool.TryGet(randomEnemyConfig.SpawnableConfig.ID, out var enemyService))
            {
                var enemyModel = new EnemyModel(randomEnemyConfig);
                enemyService = new EnemyService(
                    enemyModel,
                    _playerService.Model.Movable,
                    _playerService.DamageableService);
            }
            Model.AddSpawnedEnemy(enemyService);
            enemyService.MovableService.SetPosition(GetRandomOffScreenSpawnPosition());
        }
        
        private Vector2 GetRandomOffScreenSpawnPosition()
        {
            SpawnBorderType borderIndex = GetBorderIndex();
            float positionNormalized = GetPositionNormalized();

            Vector2 position = _cameraService.Model.Movable.Position;

            float cameraSizeX = _cameraService.Model.SizeX;
            float cameraSizeY = _cameraService.Model.CameraConfig.SizeY;

            return borderIndex switch
            {
                SpawnBorderType.Top => new Vector2(cameraSizeX * positionNormalized, position.y + (cameraSizeY / 2f)),
                SpawnBorderType.Bottom => new Vector2(cameraSizeX * positionNormalized, position.y - (cameraSizeY / 2f)),
                SpawnBorderType.Left => new Vector2(position.x - (cameraSizeX / 2f), cameraSizeY * positionNormalized),
                SpawnBorderType.Right => new Vector2(position.x + (cameraSizeX / 2f), cameraSizeY * positionNormalized),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private float GetPositionNormalized() => Random.Range(0f, 1f);

        private SpawnBorderType GetBorderIndex()
        {
            var values = Enum.GetValues(typeof(SpawnBorderType));
            return (SpawnBorderType)values.GetValue(Random.Range(0, values.Length));
        }

        public void Update(float deltaTime)
        {
            foreach (var currentSpawnedEnemy in Model.CurrentSpawnedEnemies)
            {
                currentSpawnedEnemy.Update(deltaTime);
            }

            if (Model.CurrentSpawnedEnemies.Count() < Model.Config.MaxEnemiesCount)
            {
                if (Model.CurrentSpawnDelay < 0f)
                {
                    SpawnRandomEnemy();
                }
                else
                {
                    Model.CurrentSpawnDelay -= deltaTime;
                }
            }
        }
    }
}