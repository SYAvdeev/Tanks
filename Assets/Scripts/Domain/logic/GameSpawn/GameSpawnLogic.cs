using System;
using System.Collections.Generic;
using Domain.Features;
using Domain.Logic.Damageable;
using Domain.Logic.Level;
using Domain.Logic.Startable;
using Domain.Models;
using Domain.Services;
using ReactiveTypes;
using ReactiveTypes.Extensions;

namespace Domain.Logic.GameSpawn
{
    public class GameSpawnLogic : StartableLogic, IGameSpawnLogic
    {
        private readonly IReactiveListReadOnly<string> _spawnOnStartFeatureIDs;
        private readonly IReactiveListReadOnly<string> _playerFeatureIDs;
        private readonly IReactiveListReadOnly<string> _randomEnemiesFeatureIDs;
        private readonly IReactiveListReadOnly<string> _spawnOnShootFeatureIDs;
        private readonly IReactiveProperty<int> _randomEnemiesSpawnCount;
        private readonly ISpawnOffScreenPositionLogic _spawnOffScreenPositionLogic;
        private readonly ISpawnFeatureService _spawnFeatureService;
        private readonly Random _random;

        private readonly IList<IFeature> _playerFeatures;
        private readonly IList<IFeature> _enemyFeatures;

        public GameSpawnLogic(
            IStartService startService,
            ISpawnFeatureService spawnFeatureService,
            IReactiveListReadOnly<string> spawnOnStartFeatureIDs,
            IReactiveListReadOnly<string> playerFeatureIDs, 
            IReactiveListReadOnly<string> randomEnemiesFeatureIDs,
            IReactiveListReadOnly<string> spawnOnShootFeatureIDs,
            IReactiveProperty<int> randomEnemiesSpawnCount,
            ISpawnOffScreenPositionLogic spawnOffScreenPositionLogic,
            Random random) : base(startService)
        {
            _spawnOnStartFeatureIDs = spawnOnStartFeatureIDs;
            _playerFeatureIDs = playerFeatureIDs;
            _randomEnemiesFeatureIDs = randomEnemiesFeatureIDs;
            _spawnOnShootFeatureIDs = spawnOnShootFeatureIDs;
            _randomEnemiesSpawnCount = randomEnemiesSpawnCount;
            _spawnOffScreenPositionLogic = spawnOffScreenPositionLogic;
            _spawnFeatureService = spawnFeatureService;
            _random = random;

            _playerFeatures = new List<IFeature>();
            _enemyFeatures = new List<IFeature>();
        }
        
        public override void Start()
        {
            foreach (string featureID in _spawnOnStartFeatureIDs)
            {
                _spawnFeatureService.Create(featureID);
            }
            
            foreach (string featureID in _playerFeatureIDs)
            {
                IFeature playerFeature = _spawnFeatureService.Create(featureID);
                _playerFeatures.Add(playerFeature);
            }

            for (int i = 0; i < _randomEnemiesSpawnCount.Value; i++)
            {
                SpawnRandomEnemy();
            }
        }

        private void SpawnRandomEnemy()
        {
            string randomID = _randomEnemiesFeatureIDs.Random(_random);
            IFeature enemyFeature = _spawnFeatureService.Create(randomID);
            _enemyFeatures.Add(enemyFeature);

            IModel enemyFeatureModel = enemyFeature.Model;
            IReactiveProperty<float> positionXProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.PositionX);
            IReactiveProperty<float> positionYProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.PositionY);

            (float, float) enemyCoordinates = _spawnOffScreenPositionLogic.GetRandomOffScreenSpawnPosition();

            positionXProperty.Value = enemyCoordinates.Item1;
            positionYProperty.Value = enemyCoordinates.Item2;

            if (enemyFeature.LogicCollection.TryGet(out IDamageableLogic damageableLogic))
            {
                damageableLogic.Died += OnEnemyDied;
            }
        }

        private void OnEnemyDied()
        {
            SpawnRandomEnemy();
        }

        public void SpawnOnShoot()
        {
            foreach (string featureID in _spawnOnShootFeatureIDs)
            {
                _spawnFeatureService.Create(featureID);
            }
        }
    }
}