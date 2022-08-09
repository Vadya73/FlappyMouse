using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class GameOverScreen : UIScreen
    {
        public event UnityAction RestartButtonClick;
        public override void Close()
        {
            CanvasGroup.alpha = 0;
        }

        public override void Open()
        {
            CanvasGroup.alpha = 1;
        }

        protected override void OnButtonClick()
        {
            RestartButtonClick?.Invoke();
        }
    }
}