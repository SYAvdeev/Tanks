using System;
using Domain.Services.Input;
using UnityEngine;

namespace Services
{
    public class InputService : MonoBehaviour, IInputService
    {
        [SerializeField] private KeyCode _moveKey;
        [SerializeField] private KeyCode _rotateRightKey;
        [SerializeField] private KeyCode _rotateLeftKey;
        [SerializeField] private KeyCode _shootKey;
        [SerializeField] private KeyCode _nextItemKey;
        [SerializeField] private KeyCode _previousItemKey;
        [SerializeField] private KeyCode _pauseKey;
        
        public event Action<InputType> OnInput;

        private void Update()
        {
            if (Input.GetKeyDown(_moveKey))
            {
                OnInput?.Invoke(InputType.StartMove);
            }
            else if (Input.GetKeyUp(_moveKey))
            {
                OnInput?.Invoke(InputType.StopMove);
            }

            if (Input.GetKeyDown(_rotateRightKey))
            {
                OnInput?.Invoke(InputType.StartTurnRight);
            }
            else if (Input.GetKeyUp(_rotateRightKey))
            {
                OnInput?.Invoke(InputType.StopTurnRight);
            }
            else if (Input.GetKeyDown(_rotateLeftKey))
            {
                OnInput?.Invoke(InputType.StartTurnLeft);
            }
            else if (Input.GetKeyUp(_rotateLeftKey))
            {
                OnInput?.Invoke(InputType.StopTurnLeft);
            }

            if (Input.GetKey(_shootKey))
            {
                OnInput?.Invoke(InputType.Shoot);
            }
            
            if (Input.GetKeyDown(_nextItemKey))
            {
                OnInput?.Invoke(InputType.NextItem);
            }
            
            if (Input.GetKeyDown(_previousItemKey))
            {
                OnInput?.Invoke(InputType.PreviousItem);
            }
        }
    }
}