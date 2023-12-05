using System;
using System.Collections.Generic;
using Domain.Logic.Startable;
using Domain.Services;
using Common.Extensions;
using Domain.Features;
using Domain.Logic.Damageable;
using Domain.Models;

namespace Domain.Logic.GameSpawn
{
    public class GameSpawnLogic : StartableLogic, IGameSpawnLogic
    {
        private readonly IList<string> _spawnOnStartFeatureIDs;
        private readonly IList<string> _playerFeatureIDs;
        private readonly IList<string> _randomEnemiesFeatureIDs;
        private readonly IList<string> _spawnOnShootFeatureIDs;
        private readonly int _randomFeaturesSpawnCount;
        private readonly ISpawnFeatureService _spawnFeatureService;
        private readonly Random _random;

        private readonly IList<IFeature> _playerFeatures;
        private readonly IList<IFeature> _enemyFeatures;

        public GameSpawnLogic(IStartService startService,
            IList<string> spawnOnStartFeatureIDs,
            IList<string> playerFeatureIDs, 
            IList<string> randomEnemiesFeatureIDs,
            IList<string> spawnOnShootFeatureIDs,
            int randomFeaturesSpawnCount,
            ISpawnFeatureService spawnFeatureService,
            Random random) : base(startService)
        {
            _spawnOnStartFeatureIDs = spawnOnStartFeatureIDs;
            _playerFeatureIDs = playerFeatureIDs;
            _randomEnemiesFeatureIDs = randomEnemiesFeatureIDs;
            _spawnOnShootFeatureIDs = spawnOnShootFeatureIDs;
            _randomFeaturesSpawnCount = randomFeaturesSpawnCount;
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

            for (int i = 0; i < _randomFeaturesSpawnCount; i++)
            {
                string randomID = _randomEnemiesFeatureIDs.Random(_random);
                IFeature enemyFeature = _spawnFeatureService.Create(randomID);
                _enemyFeatures.Add(enemyFeature);
                var reactiveProperty = enemyFeature.Model.GetProperty<float>(ModelPropertyName.PositionX);

                if (enemyFeature.LogicCollection.TryGet(out IDamageableLogic damageableLogic))
                {
                    damageableLogic.Died += DamageableLogicOnDied;
                }
            }
        }

        private void DamageableLogicOnDied()
        {
            _spawnFeatureService.Delete();
        }

        public void SpawnOnShoot()
        {
            foreach (string featureID in _spawnOnShootFeatureIDs)
            {
                _spawnFeatureService.Create(featureID);
            }
        }

        public void SpawnOnDied()
        {
            
        }
    }
}