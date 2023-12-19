using System;
using Domain.Features;
using Domain.Logic.Destroyable;
using Domain.Logic.Inventory;
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
        private readonly IUniqueFeaturesContainer _uniqueFeaturesContainer;
        private readonly IReactiveListReadOnly<string> _randomEnemiesFeatureIDs;
        private readonly IReactiveProperty<string> _spawnOnShootFeatureID;
        private readonly IReactiveProperty<int> _randomEnemiesSpawnCount;
        private readonly ISpawnOffScreenPositionLogic _spawnOffScreenPositionLogic;
        private readonly IInventoryLogic _inventoryLogic;
        
        private readonly IFeatureBase _playerFeatureBase;
        private readonly Random _random;
        
        public event Action<string> SpawnRandomEnemyEvent;
        public event Action<string> SpawnOnShootEvent;

        public GameSpawnLogic(
            IStartService startService,
            IUniqueFeaturesContainer uniqueFeaturesContainer,
            IReactiveListReadOnly<string> randomEnemiesFeatureIDs,
            IReactiveProperty<string> spawnOnShootFeatureID,
            IReactiveProperty<int> randomEnemiesSpawnCount,
            ISpawnOffScreenPositionLogic spawnOffScreenPositionLogic,
            IInventoryLogic inventoryLogic,
            IFeatureBase playerFeatureBase,
            Random random) : base(startService)
        {
            _uniqueFeaturesContainer = uniqueFeaturesContainer;
            _randomEnemiesFeatureIDs = randomEnemiesFeatureIDs;
            _spawnOnShootFeatureID = spawnOnShootFeatureID;
            _randomEnemiesSpawnCount = randomEnemiesSpawnCount;
            _spawnOffScreenPositionLogic = spawnOffScreenPositionLogic;
            _inventoryLogic = inventoryLogic;
            _playerFeatureBase = playerFeatureBase;
            _random = random;

            Subscribe();
        }
        
        public override void Start()
        {
            for (int i = 0; i < _randomEnemiesSpawnCount.Value; i++)
            {
                SpawnRandomEnemy();
            }
        }

        private void SpawnRandomEnemy()
        {
            string randomID = _randomEnemiesFeatureIDs.Random(_random);
            SpawnRandomEnemyEvent?.Invoke(randomID);
        }

        public void SpawnOnShoot()
        {
            SpawnOnShootEvent?.Invoke(_spawnOnShootFeatureID.Value);
        }

        public void InitializeRandomEnemy(IFeatureBase enemyFeature)
        {
            IModel enemyFeatureModel = enemyFeature.Model;
            IReactiveProperty<float> healthProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.Health);
            IReactiveProperty<float> maxHealthProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.MaxHealth);
            IReactiveProperty<float> positionXProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.PositionX);
            IReactiveProperty<float> positionYProperty = enemyFeatureModel.GetProperty<float>(ModelPropertyName.PositionY);

            (float, float) enemyCoordinates = _spawnOffScreenPositionLogic.GetRandomOffScreenSpawnPosition();

            healthProperty.Value = maxHealthProperty.Value;
            positionXProperty.Value = enemyCoordinates.Item1;
            positionYProperty.Value = enemyCoordinates.Item2;
            
            enemyFeature.LogicCollection.Get<IDestroyableFeatureLogic>().Destroyed += OnEnemyDestroyed;
            enemyFeature.LogicCollection.Get<ILookAtLogic>().Subscribe(true);
            enemyFeature.LogicCollection.Get<IMoveLogic>().Subscribe(true);
        }

        private void OnEnemyDestroyed(IFeatureBase enemyFeatureBase)
        {
            if (enemyFeatureBase.LogicCollection.TryGet(out IDestroyableFeatureLogic destroyableFeatureLogic))
            {
                destroyableFeatureLogic.Destroyed -= OnEnemyDestroyed;
            }
            SpawnRandomEnemy();
        }

        public void InitializeBullet(IFeatureBase bulletFeature)
        {
            IReactiveProperty<float> positionX = bulletFeature.Model.GetProperty<float>(ModelPropertyName.PositionX);
            IReactiveProperty<float> positionY = bulletFeature.Model.GetProperty<float>(ModelPropertyName.PositionY);
            IReactiveProperty<float> directionAngle = bulletFeature.Model.GetProperty<float>(ModelPropertyName.DirectionAngle);
            IReactiveProperty<float> damage = bulletFeature.Model.GetProperty<float>(ModelPropertyName.Damage);
            IReactiveProperty<float> speed = bulletFeature.Model.GetProperty<float>(ModelPropertyName.Speed);
                
            IReactiveProperty<float> playerPositionX = _playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionX);
            IReactiveProperty<float> playerPositionY = _playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.PositionY);
            IReactiveProperty<float> playerDirectionAngle = _playerFeatureBase.Model.GetProperty<float>(ModelPropertyName.DirectionAngle);
            IReactiveProperty<string> currentItemID = _playerFeatureBase.Model.GetProperty<string>(ModelPropertyName.CurrentItemID);

            IFeatureBase weaponFeature = _uniqueFeaturesContainer.GetFeature(currentItemID.Value);

            IReactiveProperty<float> weaponDamage = weaponFeature.Model.GetProperty<float>(ModelPropertyName.Damage);
            IReactiveProperty<float> weaponSpeed = weaponFeature.Model.GetProperty<float>(ModelPropertyName.Speed);

            positionX.Value = playerPositionX.Value;
            positionY.Value = playerPositionY.Value;
            directionAngle.Value = playerDirectionAngle.Value;
            damage.Value = weaponDamage.Value;
            speed.Value = weaponSpeed.Value;

            bulletFeature.LogicCollection.Get<IMoveLogic>().Subscribe(true);
            bulletFeature.LogicCollection.Get<IDestroyableFeatureOutOfLevelBoundsLogic>().Subscribe(true);
        }
    }
}