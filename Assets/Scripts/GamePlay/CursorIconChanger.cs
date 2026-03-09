using UnityEngine;
using UnityEngine.EventSystems;

public class CursorIconChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EnumsManager.CursorIcon cursorIcon;

    CursorIconController cursorIconController;

    private void Start()
    {
        cursorIconController = UIManager.GetInstance().GameManager.CursorIconController;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //cursorIconController.ChangeCursorIcon(cursorIcon);
        Debug.Log("CursorIconChanger: OnPointerEnter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("CursorIconChanger: OnPointerExit");
        //cursorIconController.ChangeCursorIcon(EnumsManager.CursorIcon.Default);
    }

}
