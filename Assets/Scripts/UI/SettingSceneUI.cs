using UnityEngine;

public class SettingSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Info"].onClick.AddListener(() => { GameManager.UI.ShowPopupUI("UI/InfoPopupUI"); });
        buttons["Volume"].onClick.AddListener(ClickVolumeButton);
        buttons["Setting"].onClick.AddListener(ClickSettingButton);
    }

    public void ClickVolumeButton()
    {
        Debug.Log("Volume Button");
    }

    public void ClickSettingButton()
    {
        GameManager.UI.ShowPopupUI("UI/SettingPopupUI");
    }
}
