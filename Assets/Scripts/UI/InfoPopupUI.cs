using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopupUI : PopupUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["QuitButton"].onClick.AddListener(CloseUI);
    }
}
