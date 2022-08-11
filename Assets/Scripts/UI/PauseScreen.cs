using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.UI
{
    public class PauseScreen : UIScreen
    {
        public event UnityAction UnPauseButtonClick;
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
            UnPauseButtonClick?.Invoke();
        }
    }
}