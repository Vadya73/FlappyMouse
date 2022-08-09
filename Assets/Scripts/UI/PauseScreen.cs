using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.UI
{
    public class PauseScreen : UIScreen
    {
        public event UnityAction PauseButtonClick;
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
            PauseButtonClick?.Invoke();
        }
    }
}