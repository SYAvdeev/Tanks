using Model.LevelObjects;
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
        
        private PlayerModel _playerModel;

        public void SetPlayer(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void Update()
        {
            if (!_gameplayPresenter.Pause)
            {
                if (Input.GetKeyDown(_moveKey))
                {
                    _playerModel.SetMove(true);
                }
                else if (Input.GetKeyUp(_moveKey))
                {
                    _playerModel.SetMove(false);
                }

                if (Input.GetKeyDown(_rotateRightKey))
                {
                    _playerModel.StartRotation(true);
                }
                else if (Input.GetKeyUp(_rotateRightKey))
                {
                    _playerModel.StopRotation();
                }
                else if (Input.GetKeyDown(_rotateLeftKey))
                {
                    _playerModel.StartRotation(false);
                }
                else if (Input.GetKeyUp(_rotateLeftKey))
                {
                    _playerModel.StopRotation();
                }

                if (Input.GetKey(_shootKey))
                {
                    _playerModel.Shoot();
                }
            
                if (Input.GetKeyDown(_nextWeaponKey))
                {
                    _playerModel.NextWeapon();
                }
            
                if (Input.GetKeyDown(_previousWeaponKey))
                {
                    _playerModel.PreviousWeapon();
                }
            }
            
            if (Input.GetKeyDown(_pauseKey))
            {
                _gameplayPresenter.Pause = !_gameplayPresenter.Pause;
            }
        }
    }
}