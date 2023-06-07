using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopupUI : PopupUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(CloseUI);
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.UI.ShowPopupUI("UI/ConfigPopupUI"); });
    }
}
