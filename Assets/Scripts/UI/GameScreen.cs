using UnityEngine.Events;

namespace Scripts.UI
{

}
public class GameScreen : UIScreen
{
    public event UnityAction PauseButtonClick;
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
        PauseButtonClick?.Invoke();
    }
}
