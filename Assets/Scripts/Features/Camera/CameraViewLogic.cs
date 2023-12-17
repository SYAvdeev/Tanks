namespace Features.Camera
{
    public class CameraViewLogic : BaseViewLogic<CameraViewModel, CameraViewFacade>
    {
        public CameraViewLogic(CameraViewModel viewModel, CameraViewFacade viewFacade) : 
            base(viewModel, viewFacade)
        {
            viewModel.StartInitializeModel += ViewModelOnStartInitializeModel;
        }

        private void ViewModelOnStartInitializeModel()
        {
            _viewModel.SetCameraParameters(_viewFacade.Camera.orthographicSize, _viewFacade.Camera.aspect);
        }
    }
}