using Input;
using Tanks.Utility;
using UnityEngine;

namespace Tanks.Input
{
    public class InputConfig : ConfigBase, IInputConfig
    {
        [SerializeField] private KeyCode _moveKey;
        [SerializeField] private KeyCode _rotateClockwiseKey;
        [SerializeField] private KeyCode _rotateCounterClockwiseKey;
        [SerializeField] private KeyCode _shootKey;
        [SerializeField] private KeyCode _nextWeaponKey;
        [SerializeField] private KeyCode _previousWeaponKey;

        public KeyCode MoveKey => _moveKey;
        public KeyCode RotateClockwiseKey => _rotateClockwiseKey;
        public KeyCode RotateCounterClockwiseKey => _rotateCounterClockwiseKey;
        public KeyCode ShootKey => _shootKey;
        public KeyCode NextWeaponKey => _nextWeaponKey;
        public KeyCode PreviousWeaponKey => _previousWeaponKey;
    }
}