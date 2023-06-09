using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    protected override void Awake()
    {
        base.Awake();
        data = GameManager.Resource.Load<TowerData>("Data/CannonTower");
    }

    void OnEnable()
    {
        StartCoroutine(AttackRoutine());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemyList.Count > 0)
            {
                Attack(enemyList[0]);
                yield return new WaitForSeconds(data.towers[0].speed);
            }
            else
            {
                yield return null;
            }
        }
    }

    void Attack(EnemyController target)
    {
        GameManager.Resource.Instantiate<CannonBall>("Tower/CannonBall", transform.position + transform.up * 5f, transform.rotation).SetTarget(target);
    }
}
