using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    public List<TowerInfo> towers;

    [Serializable]
    public class TowerInfo
    {
        public Tower tower;

        public int damage;
        public float range;
        public float speed;

        public float buildTime;
        public int buildCost;
        public int sellCost;
    }
}
