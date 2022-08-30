using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class PauseScreen : UIScreen
    {
        public event UnityAction UnPauseButtonClick;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton; 
        public override void Close()
        {
            CanvasGroupToInteract.alpha = 0;
            Button.interactable = false;
            _menuButton.interactable = false;
            _restartButton.interactable = false;
        }

        public override void Open()
        {
            CanvasGroupToInteract.alpha = 1;
            Button.interactable = true;
            _menuButton.interactable= true;
            _restartButton.interactable= true;
        }

        protected override void OnButtonClick()
        {
            UnPauseButtonClick?.Invoke();
        }
    }
}