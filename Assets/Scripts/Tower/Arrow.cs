using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public EnemyController enemy;
    public int damage;

    public void SetTarget(EnemyController controller, int damage = 1)
    {
        enemy = controller;
        this.damage = damage;
        StartCoroutine(ArrowRoutine());
    }

    IEnumerator ArrowRoutine()
    {
        Vector3 targetPos = Vector3.zero;
        while (true)
        {
            if (enemy != null)
                targetPos = enemy.transform.position;

            transform.LookAt(targetPos);
            transform.Translate(transform.forward * 1f, Space.World);

            if(Vector3.Distance(transform.position, enemy.transform.position) < 0.5f)
            {
                if(enemy != null)
                    Attack(enemy);
                GameManager.Resource.Destroy(gameObject);
                yield break;
            }

            yield return new WaitForSeconds(.01f);
        }
    }

    void Attack(EnemyController target)
    {
        target.TakeDamage(damage);
    }
}
