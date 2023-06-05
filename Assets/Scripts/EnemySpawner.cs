using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float spawnTime;

    void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            GameObject enemy = GameManager.Resource.Instantiate<GameObject>("Prefabs/EnemyWizard", waypoints[0].transform.position, waypoints[0].transform.rotation, true);
            enemy.GetComponent<EnemyMover>().StartMove(waypoints);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
