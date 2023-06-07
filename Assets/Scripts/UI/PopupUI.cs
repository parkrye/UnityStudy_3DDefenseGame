using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void CloseUI()
    {
        base.CloseUI();

        GameManager.UI.ClosePopupUI();
    }
}
