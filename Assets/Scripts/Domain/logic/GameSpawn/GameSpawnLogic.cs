using System;
using System.Collections.Generic;
using Domain.Features;
using Domain.Logic.Destroyable;
using Domain.Logic.Enemy;
using Domain.Logic.Level;
using Domain.Logic.Startable;
using Domain.Logic.Transformable;
using Domain.Models;
using Domain.Services;
using ReactiveTypes;
using ReactiveTypes.Extensions;

namespace Domain.Logic.GameSpawn
{
    public class GameSpawnLogic : StartableLogic, IGameSpawnLogic
    {
        private readonly IReactiveListReadOnly<string> _spawnOnStartFeatureIDs;
        private readonly IReactiveListReadOnly<string> _randomEnemiesFeatureIDs;
        private readonly IReactiveListReadOnly<string> _spawnOnShootFeatureIDs;
        private readonly IReactiveProperty<int> _randomEnemiesSpawnCount;
        private readonly ISpawnOffScreenPositionLogic _spawnOffScreenPositionLogic;
        
        private readonly IFeature _playerFeature;

        private readonly ISpawnFeatureService _spawnFeatureService;
        private readonly Random _random;

        private readonly IList<IFeature> _enemyFeatures;

        public GameSpawnLogic(
            IStartService startService,
            ISpawnFeatureService spawnFeatureService,
            IReactiveListReadOnly<string> spawnOnStartFeatureIDs,
            IReactiveListReadOnly<string> randomEnemiesFeatureIDs,
            IReactiveListReadOnly<string> spawnOnShootFeatureIDs,
            IReactiveProperty<int> randomEnemiesSpawnCount,
            ISpawnOffScreenPositionLogic spawnOffScreenPositionLogic,
            IFeature playerFeature,
            Random random) : base(startService)
        {
            _spawnOnStartFeatureIDs = spawnOnStartFeatureIDs;
            _randomEnemiesFeatureIDs = randomEnemiesFeatureIDs;
            _spawnOnShootFeatureIDs = spawnOnShootFeatureIDs;
            _randomEnemiesSpawnCount = randomEnemiesSpawnCount;
            _spawnOffScreenPositionLogic = spawnOffScreenPositionLogic;
            _playerFeature = playerFeature;
            _spawnFeatureService = spawnFeatureService;
            _random = random;

            _enemyFeatures = new List<IFeature>();
            Subscribe();
        }
        
        public override async void Start()
        {
            foreach (string featureID in _spawnOnStartFeatureIDs)
            {
                await _spawnFeatureService.Create(featureID);
            }

            for (int i = 0; i < _randomEnemiesSpawnCount.Value; i++)
            {
                SpawnRandomEnemy();
            }
        }

        private async void SpawnRandomEnemy()
        {
            string randomID = _randomEnemiesFeatureIDs.Random(_random);
            IFeature enemyFeature = await _spawnFeatureService.Create(randomID);
            _enemyFeatures.Add(enemyFeature);

            IModel enemyFeatureModel = enemyFeature.Model;
            IReactiveProperty<float> positionXProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.PositionX);
            IReactiveProperty<float> positionYProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.PositionY);

            (float, float) enemyCoordinates = _spawnOffScreenPositionLogic.GetRandomOffScreenSpawnPosition();

            positionXProperty.Value = enemyCoordinates.Item1;
            positionYProperty.Value = enemyCoordinates.Item2;

            if (enemyFeature.LogicCollection.TryGet(out IDestroyableFeatureLogic destroyableFeatureLogic))
            {
                destroyableFeatureLogic.Destroyed += OnEnemyDestroyed;
            }
            
            if (enemyFeature.LogicCollection.TryGet(out IEnemyOnSpawnLogic enemyOnSpawnLogic))
            {
                enemyOnSpawnLogic.Subscribe();
            }
            
            _enemyFeatures.Add(enemyFeature);
        }

        private void OnEnemyDestroyed(IFeature enemyFeature)
        {
            _enemyFeatures.Remove(enemyFeature);
            if (enemyFeature.LogicCollection.TryGet(out IDestroyableFeatureLogic destroyableFeatureLogic))
            {
                destroyableFeatureLogic.Destroyed -= OnEnemyDestroyed;
            }
            SpawnRandomEnemy();
        }

        public async void SpawnOnShoot()
        {
            foreach (string featureID in _spawnOnShootFeatureIDs)
            {
                IFeature feature = await _spawnFeatureService.Create(featureID);

                IReactiveProperty<float> positionX = feature.Model.GetProperty<float>(ModelPropertyName.PositionX);
                IReactiveProperty<float> positionY = feature.Model.GetProperty<float>(ModelPropertyName.PositionY);
                IReactiveProperty<float> directionAngle = feature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle);
                
                IReactiveProperty<float> playerPositionX = _playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionX);
                IReactiveProperty<float> playerPositionY = _playerFeature.Model.GetProperty<float>(ModelPropertyName.PositionY);
                IReactiveProperty<float> playerDirectionAngle = _playerFeature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle);

                positionX.Value = playerPositionX.Value;
                positionY.Value = playerPositionY.Value;
                directionAngle.Value = playerDirectionAngle.Value;
                
                feature.LogicCollection.Get<IMoveLogic>().Subscribe(true);
            }
        }
    }
}