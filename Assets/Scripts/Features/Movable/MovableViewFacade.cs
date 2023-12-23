using UnityEngine;

namespace Features.Movable
{
    public class MovableViewFacade : BaseViewFacade
    {
        [SerializeField]
        private Transform _transform;
        [SerializeField]
        private Transform _rotationTransform;

        public Transform Transform => _transform;
        public Transform RotationTransform => _rotationTransform;
    }
}