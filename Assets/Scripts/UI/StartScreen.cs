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
            PlayButtonClick?.Invoke();
        }
    }
}