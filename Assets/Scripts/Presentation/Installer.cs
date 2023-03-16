using Data.Config;
using Model.UseCase;
using UnityEngine;

namespace Presentation
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameplayPresenter _gameplayPresenter;
        [SerializeField] private Config _config;
    
        private void Start()
        {
            GameplayUseCase gameplayUseCase = new GameplayUseCase(_gameplayPresenter, _config, _camera.aspect);
            _gameplayPresenter.Initialize(gameplayUseCase);
        }
    }
}