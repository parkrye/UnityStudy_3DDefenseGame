using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public EnemyController enemy;
    public int damage = 1, time = 3;

    public void SetTarget(EnemyController controller, int damage = 1)
    {
        enemy = controller;
        this.damage = damage;
        StartCoroutine(CannonBallRoutine());
    }

    IEnumerator CannonBallRoutine()
    {
        Vector3 targetPos = enemy.transform.position;

        float xSpeed = (targetPos.x - transform.position.x) / time;
        float zSpeed = (targetPos.z - transform.position.z) / time;
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + transform.position.y) / time;

        float curTime = 0;

        while( curTime < time)
        {
            curTime += Time.deltaTime;

            transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;
            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (Vector3.Distance(transform.position, enemy.transform.position) < 0.1f)
            {
                if (enemy != null)
                    Attack();
                GameManager.Resource.Destroy(gameObject);
                yield break;
            }
            yield return null;
        }
    }

    void Attack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
        foreach(Collider collider in colliders)
        {
            EnemyController enemy = collider.GetComponent<EnemyController>();
            enemy?.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
