using Data.Config;
using Domain.Features;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private ConfigScriptableObject configScriptableObject;

        public override void InstallBindings()
        {
            
            
            //Container.Bind<IFeature>().WithId("id").FromMethod()
            
        }
    }
}