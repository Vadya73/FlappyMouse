using Scripts.Hero;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameOverScreen : UIScreen
    {
        public event UnityAction RestartButtonClick;
        
        [SerializeField] private Button _menuButton;
        [SerializeField] private HeroStatsHolder _heroStatsHolder;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public override void Close()
        {
            CanvasGroupToInteract.alpha = 0;
            Button.interactable = false;
            _menuButton.interactable= false;
        }

        public override void Open()
        {
            CanvasGroupToInteract.alpha = 1;
            _scoreText.text = _heroStatsHolder.Score.ToString();
            Button.interactable = true;
            _menuButton.interactable = true;
        }

        protected override void OnButtonClick() 
        {
            RestartButtonClick?.Invoke();
        }
    }
}