using System.Collections.Generic;
using Model.LevelObjects;
using Model.LevelObjects.Spawner;

namespace Model.UseCase
{
    public class GameplayUseCase
    {
        private readonly IGameplayPresenter _gameplayPresenter;
        private readonly IConfigRepository _configRepository;
        
        private readonly LevelObjectModelsSpawner _levelObjectModelsSpawner;
        private readonly List<BulletModel> _bullets = new(10);
        
        private PlayerModel _playerModel;
        private List<EnemyModel> _enemies;

        public GameplayUseCase(IGameplayPresenter gameplayPresenter, IConfigRepository configRepository, float levelAspectRatio)
        {
            _gameplayPresenter = gameplayPresenter;
            _configRepository = configRepository;

            _levelObjectModelsSpawner = new LevelObjectModelsSpawner(configRepository.SpawnModelConfig, levelAspectRatio);
        }

        public void StartGame()
        {
            _playerModel = _levelObjectModelsSpawner.SpawnPlayer(_configRepository.PlayerModelConfig, _configRepository.WeaponModelConfigs);
            _enemies = _levelObjectModelsSpawner.SpawnEnemiesRandom(_configRepository.EnemyModelConfigs);
            _gameplayPresenter.OnGameStarted(_playerModel, _enemies);
            
            _playerModel.OnShoot += OnShoot;
            _playerModel.OnDestroy += Lose;
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].OnDestroy += OnEnemyDestroyed;
                _enemies[i].OnDestroy += RespawnEnemy;
            }
        }

        public void Tick(float deltaTime)
        {
            _playerModel.TickBehaviours(deltaTime);
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].TickBehaviours(deltaTime);
            }
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i].TickBehaviours(deltaTime);
            }
        }

        private void Lose(LevelObjectModel levelObjectModel)
        {
            _gameplayPresenter.OnLose();
            _playerModel.ClearDestroyEvent();
            for (int i = _enemies.Count - 1; i >= 0; --i)
            {
                EnemyModel enemyModel = _enemies[i];
                enemyModel.OnDestroy -= RespawnEnemy;
                enemyModel.Destroy(true);
            }
            for (int i = _bullets.Count - 1; i >= 0; --i)
            {
                _bullets[i].Destroy(true);
            }
            _enemies.Clear();
            _bullets.Clear();
        }
        
        private void OnShoot(BulletModel bulletModel)
        {
            _bullets.Add(bulletModel);
            bulletModel.OnDestroy += OnBulletDestroyed;
            _gameplayPresenter.OnShoot(bulletModel);
        }

        private void OnEnemyDestroyed(LevelObjectModel levelObjectModel)
        {
            EnemyModel enemyModel = (EnemyModel)levelObjectModel;
            _enemies.Remove(enemyModel);
            _levelObjectModelsSpawner.PushToPool(enemyModel);
            enemyModel.ClearDestroyEvent();
        }

        private void RespawnEnemy(LevelObjectModel levelObjectModel)
        {
            EnemyModel enemyModel = _levelObjectModelsSpawner.SpawnEnemyRandom(_configRepository.EnemyModelConfigs);
            _enemies.Add(enemyModel);
            _gameplayPresenter.OnEnemySpawned(enemyModel);
            enemyModel.OnDestroy += OnEnemyDestroyed;
            enemyModel.OnDestroy += RespawnEnemy;
        }
        
        private void OnBulletDestroyed(LevelObjectModel levelObjectModel)
        {
            BulletModel bulletModel = (BulletModel)levelObjectModel;
            _bullets.Remove(bulletModel);
            _levelObjectModelsSpawner.PushToPool(bulletModel);
            bulletModel.ClearDestroyEvent();
        }
    }
}