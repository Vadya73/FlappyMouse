using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.UI
{
    public class StartScreen : UIScreen
    {
        public event UnityAction PlayButtonClick;
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
            PlayButtonClick?.Invoke();
        }
    }
}