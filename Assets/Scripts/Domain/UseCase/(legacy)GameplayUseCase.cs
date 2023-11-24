// using System.Collections.Generic;
// using Domain.Models;
// using Domain.Models.Spawner;
//
// namespace Domain.UseCase
// {
//     public class GameplayUseCase
//     {
//         private readonly IGameplayPresenter _gameplayPresenter;
//         private readonly IConfigRepository _configRepository;
//         
//         private readonly LevelObjectModelsSpawner _levelObjectModelsSpawner;
//         private readonly List<DamagerModel> _bullets = new(10);
//         
//         private WeaponsInventoryModel _weaponsInventoryModel;
//         private List<EnemyModel> _enemies;
//
//         public GameplayUseCase(IGameplayPresenter gameplayPresenter, IConfigRepository configRepository, float levelAspectRatio)
//         {
//             _gameplayPresenter = gameplayPresenter;
//             _configRepository = configRepository;
//
//             _levelObjectModelsSpawner = new LevelObjectModelsSpawner(configRepository.SpawnModelConfig, levelAspectRatio);
//         }
//
//         public void StartGame()
//         {
//             _weaponsInventoryModel = _levelObjectModelsSpawner.SpawnPlayer(_configRepository.PlayerModelConfig, _configRepository.WeaponModelConfigs);
//             _enemies = _levelObjectModelsSpawner.SpawnEnemiesRandom(_configRepository.EnemyModelConfigs);
//             _gameplayPresenter.OnGameStarted(_weaponsInventoryModel, _enemies);
//             
//             _weaponsInventoryModel.OnShoot += OnShoot;
//             _weaponsInventoryModel.OnDestroy += Lose;
//             for (int i = 0; i < _enemies.Count; i++)
//             {
//                 _enemies[i].OnDestroy += OnEnemyDestroyed;
//                 _enemies[i].OnDestroy += RespawnEnemy;
//             }
//         }
//
//         public void Tick(float deltaTime)
//         {
//             _weaponsInventoryModel.TickBehaviours(deltaTime);
//             for (int i = 0; i < _enemies.Count; i++)
//             {
//                 _enemies[i].TickBehaviours(deltaTime);
//             }
//             for (int i = 0; i < _bullets.Count; i++)
//             {
//                 _bullets[i].TickBehaviours(deltaTime);
//             }
//         }
//
//         private void Lose(TransformableModel transformableModel)
//         {
//             _gameplayPresenter.OnLose();
//             _weaponsInventoryModel.ClearDestroyEvent();
//             for (int i = _enemies.Count - 1; i >= 0; --i)
//             {
//                 EnemyModel enemyModel = _enemies[i];
//                 enemyModel.OnDestroy -= RespawnEnemy;
//                 enemyModel.Destroy(true);
//             }
//             for (int i = _bullets.Count - 1; i >= 0; --i)
//             {
//                 _bullets[i].Destroy(true);
//             }
//             _enemies.Clear();
//             _bullets.Clear();
//         }
//         
//         private void OnShoot(DamagerModel damagerModel)
//         {
//             _bullets.Add(damagerModel);
//             damagerModel.OnDestroy += OnBulletDestroyed;
//             _gameplayPresenter.OnShoot(damagerModel);
//         }
//
//         private void OnEnemyDestroyed(TransformableModel transformableModel)
//         {
//             EnemyModel enemyModel = (EnemyModel)transformableModel;
//             _enemies.Remove(enemyModel);
//             _levelObjectModelsSpawner.PushToPool(enemyModel);
//             enemyModel.ClearDestroyEvent();
//         }
//
//         private void RespawnEnemy(TransformableModel transformableModel)
//         {
//             EnemyModel enemyModel = _levelObjectModelsSpawner.SpawnEnemyRandom(_configRepository.EnemyModelConfigs);
//             _enemies.Add(enemyModel);
//             _gameplayPresenter.OnEnemySpawned(enemyModel);
//             enemyModel.OnDestroy += OnEnemyDestroyed;
//             enemyModel.OnDestroy += RespawnEnemy;
//         }
//         
//         private void OnBulletDestroyed(TransformableModel transformableModel)
//         {
//             DamagerModel damagerModel = (DamagerModel)transformableModel;
//             _bullets.Remove(damagerModel);
//             _levelObjectModelsSpawner.PushToPool(damagerModel);
//             damagerModel.ClearDestroyEvent();
//         }
//     }
// }