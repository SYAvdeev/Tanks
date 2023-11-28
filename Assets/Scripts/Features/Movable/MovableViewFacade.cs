using UnityEngine;

namespace Features.Movable
{
    public class MovableViewFacade : BaseViewFacade
    {
        [SerializeField]
        private Transform _transform;

        public Transform Transform => _transform;
    }
}