using UnityEngine;

namespace Scripts.UI
{
    public class UISwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseCanvas;
        [SerializeField] private GameObject _deathCanvas;
        [SerializeField] private GameObject _gameCanvas;

        public bool _isAlive;

        private void Start()
        {
            _isAlive = true;
        }
        private void Update()
        {
            if (!_isAlive)
                ShowDeathCanvas();
        }
        public void ShowDeathCanvas()
        {
            _isAlive = false;

            _gameCanvas.SetActive(false);
            _deathCanvas.SetActive(true);
        }

        public void TogglePauseCanvas()
        {
            _pauseCanvas.SetActive(!_pauseCanvas.activeSelf);

            if (_pauseCanvas.activeSelf)
            {
                Time.timeScale = 0f;
                _gameCanvas.SetActive(false);
            }
            else
            {
                _gameCanvas.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
}