using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : Tower
{
    protected override void Awake()
    {
        base.Awake();
        data = GameManager.Resource.Load<TowerData>("Data/MageTower");
    }
}
