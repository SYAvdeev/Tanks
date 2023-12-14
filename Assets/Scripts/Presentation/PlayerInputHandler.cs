using UnityEngine;

namespace Presentation
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private KeyCode _moveKey;
        [SerializeField] private KeyCode _rotateRightKey;
        [SerializeField] private KeyCode _rotateLeftKey;
        [SerializeField] private KeyCode _shootKey;
        [SerializeField] private KeyCode _nextWeaponKey;
        [SerializeField] private KeyCode _previousWeaponKey;
        [SerializeField] private KeyCode _pauseKey;

        private void Update()
        {
            if (Input.GetKeyDown(_moveKey))
                {
                    
                }
                else if (Input.GetKeyUp(_moveKey))
                {
                    
                }

                if (Input.GetKeyDown(_rotateRightKey))
                {
                    
                }
                else if (Input.GetKeyUp(_rotateRightKey))
                {
                    
                }
                else if (Input.GetKeyDown(_rotateLeftKey))
                {
                    
                }
                else if (Input.GetKeyUp(_rotateLeftKey))
                {
                    
                }

                if (Input.GetKey(_shootKey))
                {
                    
                }
            
                if (Input.GetKeyDown(_nextWeaponKey))
                {
                    
                    
                }
            
                if (Input.GetKeyDown(_previousWeaponKey))
                {
                    
                }
            
        }
    }
}