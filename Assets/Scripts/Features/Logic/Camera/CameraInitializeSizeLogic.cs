using Cysharp.Threading.Tasks;
using Features.Camera;
using ReactiveTypes;
using Services.Factory.ViewModel;

namespace Features.Logic.Camera
{
    public class CameraInitializeSizeLogic : ICameraInitializeSizeLogic, IInitializableAfterBuildLogic
    {
        private readonly IReactiveProperty<float> _sizeXProperty;
        private readonly IReactiveProperty<float> _sizeYProperty;
        private readonly IFeature _cameraFeature;

        public CameraInitializeSizeLogic(
            IReactiveProperty<float> sizeXProperty,
            IReactiveProperty<float> sizeYProperty,
            IFeature cameraFeature)
        {
            _sizeXProperty = sizeXProperty;
            _sizeYProperty = sizeYProperty;
            _cameraFeature = cameraFeature;
        }

        public UniTask Initialize()
        {
            UnityEngine.Camera camera = _cameraFeature.ViewRoot.GetViewFacade<CameraViewFacade>(ViewType.Camera).Camera;
            _sizeYProperty.Value = 2f * camera.orthographicSize;
            _sizeXProperty.Value = _sizeYProperty.Value * camera.aspect;
            
            return UniTask.CompletedTask;
        }
    }
}