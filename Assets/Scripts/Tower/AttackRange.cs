using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public LayerMask enemyMask;

    public UnityEvent<EnemyController> OnInRangeEnemy, OnOutRangeEnemy;

    void OnTriggerEnter(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if(enemy != null)
            {
                OnInRangeEnemy?.Invoke(enemy);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (enemyMask.IsContain(other.gameObject.layer))
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                OnOutRangeEnemy?.Invoke(enemy);
            }
        }
    }
}
