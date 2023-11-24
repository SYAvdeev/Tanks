using Domain.Models;
using UnityEngine;

namespace Presentation
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private GameplayPresenter _gameplayPresenter;
        [SerializeField] private KeyCode _moveKey;
        [SerializeField] private KeyCode _rotateRightKey;
        [SerializeField] private KeyCode _rotateLeftKey;
        [SerializeField] private KeyCode _shootKey;
        [SerializeField] private KeyCode _nextWeaponKey;
        [SerializeField] private KeyCode _previousWeaponKey;
        [SerializeField] private KeyCode _pauseKey;
        
        private WeaponsInventoryModel _weaponsInventoryModel;

        public void SetPlayer(WeaponsInventoryModel weaponsInventoryModel)
        {
            _weaponsInventoryModel = weaponsInventoryModel;
        }

        private void Update()
        {
            if (!_gameplayPresenter.Pause)
            {
                if (Input.GetKeyDown(_moveKey))
                {
                    _weaponsInventoryModel.SetMove(true);
                }
                else if (Input.GetKeyUp(_moveKey))
                {
                    _weaponsInventoryModel.SetMove(false);
                }

                if (Input.GetKeyDown(_rotateRightKey))
                {
                    _weaponsInventoryModel.StartRotation(true);
                }
                else if (Input.GetKeyUp(_rotateRightKey))
                {
                    _weaponsInventoryModel.StopRotation();
                }
                else if (Input.GetKeyDown(_rotateLeftKey))
                {
                    _weaponsInventoryModel.StartRotation(false);
                }
                else if (Input.GetKeyUp(_rotateLeftKey))
                {
                    _weaponsInventoryModel.StopRotation();
                }

                if (Input.GetKey(_shootKey))
                {
                    _weaponsInventoryModel.Shoot();
                }
            
                if (Input.GetKeyDown(_nextWeaponKey))
                {
                    _weaponsInventoryModel.NextWeapon();
                }
            
                if (Input.GetKeyDown(_previousWeaponKey))
                {
                    _weaponsInventoryModel.PreviousWeapon();
                }
            }
            
            if (Input.GetKeyDown(_pauseKey))
            {
                _gameplayPresenter.Pause = !_gameplayPresenter.Pause;
            }
        }
    }
}