using Data.Config;
using Domain.UseCase;
using UnityEngine;

namespace Presentation
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameplayPresenter _gameplayPresenter;
        [SerializeField] private ConfigScriptableObject configScriptableObject;
    
        private void Start()
        {
            GameplayUseCase gameplayUseCase = new GameplayUseCase(_gameplayPresenter, configScriptableObject, _camera.aspect);
            _gameplayPresenter.Initialize(gameplayUseCase);
        }
    }
}