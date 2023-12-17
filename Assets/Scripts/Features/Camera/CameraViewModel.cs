using System;
using Domain.Logic;
using Domain.Logic.Camera;
using Domain.Models;

namespace Features.Camera
{
    public class CameraViewModel : BaseViewModel
    {
        private readonly ICameraInitializeSizeLogic _cameraInitializeSizeLogic;

        public event Action StartInitializeModel;
        
        public CameraViewModel(IModel model, ILogicCollection logicCollection) : base(model, logicCollection)
        {
            _cameraInitializeSizeLogic = logicCollection.Get<ICameraInitializeSizeLogic>();
            _cameraInitializeSizeLogic.StartInitialize += CameraInitializeSizeLogicOnStartInitialize;
        }
        
        public void SetCameraParameters(float cameraSize, float aspectRatio)
        {
            _cameraInitializeSizeLogic.SetParameters(cameraSize, aspectRatio);
        }

        private void CameraInitializeSizeLogicOnStartInitialize()
        {
            StartInitializeModel?.Invoke();
        }
    }
}