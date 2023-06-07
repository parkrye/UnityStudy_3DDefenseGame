using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigPopupUI : PopupUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["OKButton"].onClick.AddListener(CloseUI);
        buttons["CancelButton"].onClick.AddListener(CloseUI);
    }
}
