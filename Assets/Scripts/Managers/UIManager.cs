using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    EventSystem eventSystem;
    Canvas popupCanvas;
    Stack<PopupUI> popupStack;

    void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popupCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popupCanvas.gameObject.name = "PopupCanvas";
        popupCanvas.sortingOrder = 100;

        popupStack = new Stack<PopupUI>();
    }

    public T ShowPopupUI<T>(T popup) where T : PopupUI
    {
        if(popupStack.Count > 0)
        {
            popupStack.Peek().gameObject.SetActive(false);
        }

        T ui = GameManager.Pool.GetUI<T>(popup);
        ui.transform.SetParent(popupCanvas.transform, false);

        popupStack.Push(ui);

        Time.timeScale = 0f;

        return ui;
    }

    public void ShowPopupUI(string path)
    {
        PopupUI uI = GameManager.Resource.Load<PopupUI>(path);
        ShowPopupUI(uI);
    }

    public void ClosePopupUI()
    {
        GameManager.Pool.Release(popupStack.Pop());

        if(popupStack.Count == 0)
            Time.timeScale = 1f;

        if (popupStack.Count > 0)
        {
            popupStack.Peek().gameObject.SetActive(true);
        }
    }
}
