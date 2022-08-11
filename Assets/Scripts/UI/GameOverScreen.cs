using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameOverScreen : UIScreen
    {
        public event UnityAction RestartButtonClick;

        public override void Close()
        {
            CanvasGroupToInteract.alpha = 0;
            Button.interactable = false;
        }

        public override void Open()
        {
            CanvasGroupToInteract.alpha = 1;
            Button.interactable = true;
        }

        protected override void OnButtonClick()
        {
            RestartButtonClick?.Invoke();
        }
    }
}