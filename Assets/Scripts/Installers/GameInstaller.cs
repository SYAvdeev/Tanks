using Data.Config;
using Domain.Features;
using Presentation;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameplayPresenter _gameplayPresenter;
        [SerializeField] private ConfigScriptableObject configScriptableObject;

        public override void InstallBindings()
        {
            
            
            Container.Bind<IFeature>().WithId("Pidor").FromMethod()
            
        }
        
        

        private void Start()
        {
            GameplayUseCase gameplayUseCase = new GameplayUseCase(_gameplayPresenter, configScriptableObject, _camera.aspect);
            _gameplayPresenter.Initialize(gameplayUseCase);
        }
    }
}