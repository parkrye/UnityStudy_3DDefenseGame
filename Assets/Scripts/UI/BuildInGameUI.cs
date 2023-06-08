using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;

    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI(this); });
        buttons["Bow"].onClick.AddListener(BuildBow);
        buttons["Cannon"].onClick.AddListener(BuildCannon);
        buttons["Wizard"].onClick.AddListener(BuildMage);
    }

    void BuildBow()
    {
        if(towerPlace != null)
        {
            TowerData towerData = GameManager.Resource.Load<TowerData>("Data/ArcherTower");
            towerPlace.BuildTower(towerData);
            GameManager.UI.CloseInGameUI(this);
        }
    }

    void BuildCannon()
    {
        if (towerPlace != null)
        {
            TowerData towerData = GameManager.Resource.Load<TowerData>("Data/CannonTower");
            towerPlace.BuildTower(towerData);
            GameManager.UI.CloseInGameUI(this);
        }
    }

    void BuildMage()
    {
        if (towerPlace != null)
        {
            TowerData towerData = GameManager.Resource.Load<TowerData>("Data/MageTower");
            towerPlace.BuildTower(towerData);
            GameManager.UI.CloseInGameUI(this);
        }
    }
}
