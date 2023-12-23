using UnityEngine;

namespace Features.Camera
{
    public class CameraViewFacade : BaseViewFacade
    {
        [SerializeField]
        private UnityEngine.Camera _camera;

        public UnityEngine.Camera Camera => _camera;
    }
}