using UnityEngine;
using UnityEngine.UI;

public abstract class UIScreen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroupToInteract;
    [SerializeField] protected Button Button;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public abstract void Open();

    public abstract void Close();
}