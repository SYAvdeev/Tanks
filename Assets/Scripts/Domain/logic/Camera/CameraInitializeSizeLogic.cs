using System;
using Domain.Logic.Startable;
using Domain.Services;
using ReactiveTypes;

namespace Domain.Logic.Camera
{
    public class CameraInitializeSizeLogic : StartableLogic, ICameraInitializeSizeLogic
    {
        private readonly IReactiveProperty<float> _sizeXProperty;
        private readonly IReactiveProperty<float> _sizeYProperty;

        public event Action StartInitialize;

        public CameraInitializeSizeLogic(
            IStartService startService, 
            IReactiveProperty<float> sizeXProperty, 
            IReactiveProperty<float> sizeYProperty) : 
            base(startService)
        {
            _sizeXProperty = sizeXProperty;
            _sizeYProperty = sizeYProperty;
            Subscribe();
        }

        public override void Start()
        {
            StartInitialize?.Invoke();
        }

        public void SetParameters(float cameraSize, float aspectRatio)
        {
            _sizeYProperty.Value = 2f * cameraSize;
            _sizeXProperty.Value = _sizeYProperty.Value * aspectRatio;
        }
    }
}