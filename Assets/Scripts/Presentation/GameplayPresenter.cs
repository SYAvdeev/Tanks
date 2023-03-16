using System.Collections;
using System.Collections.Generic;
using Model.LevelObjects;
using Model.UseCase;
using Presentation.LevelObjects;
using UI;
using UnityEngine;

namespace Presentation
{
    public class GameplayPresenter : MonoBehaviour, IGameplayPresenter
    {
        [SerializeField] private PlayerPresenter _playerPresenter;
        [SerializeField] private SceneObjectsSpawner _sceneObjectsSpawner;
        [SerializeField] private Transform _levelObjectsParent;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private GameMenu _gameMenu;

        private GameplayUseCase _gameplayUseCase;
        private Coroutine _updateRoutine;

        private bool _pause;

        public bool Pause
        {
            get => _pause;
            set
            {
                if (value && _updateRoutine != null)
                {
                    StopCoroutine(_updateRoutine);
                    _updateRoutine = null;
                    _gameMenu.ShowPause();
                }
                else
                {
                    _updateRoutine = StartCoroutine(UpdateRoutine());
                }

                _pause = value;
            }
        }

        public void Initialize(GameplayUseCase gameplayUseCase)
        {
            _gameplayUseCase = gameplayUseCase;
        }

        public void StartGame()
        {
            _gameplayUseCase.StartGame();
        }
        
        public void ContinueGame()
        {
            Pause = false;
        }

        public void OnGameStarted(PlayerModel playerModel, List<EnemyModel> enemies)
        {
            _playerPresenter.gameObject.SetActive(true);
            _playerPresenter.SetLevelObject(playerModel);
            _playerInputHandler.SetPlayer(playerModel);

            for (int i = 0; i < enemies.Count; i++)
            {
                _sceneObjectsSpawner.SpawnEnemy(enemies[i], _levelObjectsParent);
            }
            
            if (_updateRoutine != null)
            {
                StopCoroutine(_updateRoutine);
                _updateRoutine = null;
            }
            
            Pause = false;
            _playerInputHandler.enabled = true;
        }

        public void OnLose()
        {
            Pause = true;
            _gameMenu.ShowGameOver();
            _playerInputHandler.enabled = false;
        }

        public void OnShoot(BulletModel bulletModel)
        {
            _sceneObjectsSpawner.SpawnBullet(bulletModel, _levelObjectsParent);
        }

        public void OnEnemySpawned(EnemyModel enemyModel)
        {
            _sceneObjectsSpawner.SpawnEnemy(enemyModel, _levelObjectsParent);
        }

        private IEnumerator UpdateRoutine()
        {
            while (true)
            {
                _gameplayUseCase.Tick(Time.deltaTime);
                yield return null;
            }
        }

        private void OnDestroy()
        {
            if (_updateRoutine != null)
            {
                StopCoroutine(_updateRoutine);
            }
        }
    }
}