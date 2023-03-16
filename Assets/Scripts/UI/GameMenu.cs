using UnityEngine;

namespace UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _startGameButton;
        [SerializeField] private GameObject _continueButton;
        [SerializeField] private GameObject _gameOverText;

        public void Start()
        {
            gameObject.SetActive(true);
        }

        public void ShowGameOver()
        {
            gameObject.SetActive(true);
            _startGameButton.SetActive(true);
            _continueButton.SetActive(false);
            _gameOverText.SetActive(true);
        }
        
        public void ShowPause()
        {
            gameObject.SetActive(true);
            _startGameButton.SetActive(false);
            _continueButton.SetActive(true);
            _gameOverText.SetActive(false);
        }
    }
}

