using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    EventSystem eventSystem;
    Canvas sceneCanvas, ingameCanvas, windowCanvas, popupCanvas;
    Stack<PopupUI> popupStack;

    void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        ingameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        ingameCanvas.gameObject.name = "InGameCanvas";
        ingameCanvas.sortingOrder = 0;

        sceneCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        sceneCanvas.gameObject.name = "SceneCanvas";
        sceneCanvas.sortingOrder = 1;

        windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        windowCanvas.gameObject.name = "WindowCanvas";
        windowCanvas.sortingOrder = 10;

        popupCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popupCanvas.gameObject.name = "PopupCanvas";
        popupCanvas.sortingOrder = 100;

        popupStack = new Stack<PopupUI>();
    }

    void Start()
    {
        InfoSceneUI infoSceneUI = GameManager.Resource.Instantiate<InfoSceneUI>("UI/InfoSceneUI");
        SettingSceneUI settingSceneUI = GameManager.Resource.Instantiate<SettingSceneUI>("UI/SettingSceneUI");
        infoSceneUI.transform.SetParent(sceneCanvas.transform, false);
        settingSceneUI.transform.SetParent(sceneCanvas.transform, false);
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

    public void ShowWindowUI(WindowUI windowUI)
    {
        WindowUI ui = GameManager.Pool.GetUI(windowUI);
        ui.transform.SetParent(windowCanvas.transform, false);
    }

    public void ShowWindowUI(string path)
    {
        WindowUI uI = GameManager.Resource.Load<WindowUI>(path);
        ShowWindowUI(uI);
    }

    public void SelectWindowUI(WindowUI windowUI)
    {
        windowUI.transform.SetAsLastSibling();
    }

    public void CLoseWindowUI(WindowUI windowUI)
    {
        GameManager.Pool.ReleaseUI(windowUI);
    }

    public T ShowInGameUI<T>(T inGameUI) where T : InGameUI
    {
        T ui = GameManager.Pool.GetUI(inGameUI);
        ui.transform.SetParent(ingameCanvas.transform, false);

        return ui;
    }

    public T ShowInGameUI<T>(string path) where T : InGameUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowInGameUI(ui);
    }

    public void CloseInGameUI(InGameUI inGameUI)
    {
        GameManager.Pool.Release(inGameUI);
    }
}
