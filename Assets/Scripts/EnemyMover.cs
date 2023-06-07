using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    Transform[] waypoints;
    [SerializeField] int nowPoint;

    void Update()
    {
        CheckWayPoint();
    }

    public void StartMove(Transform[] _waypoints)
    {
        nowPoint = 0;
        waypoints = _waypoints;
        agent.enabled = true;
        agent.SetDestination(waypoints[nowPoint].position);
    }

    void CheckWayPoint()
    {
        if(agent.remainingDistance < 0.5f)
        {
            nowPoint++;
            if(nowPoint < waypoints.Length)
            {
                agent.SetDestination(waypoints[nowPoint].position);
            }
            else
            {
                agent.enabled = false;
                GameManager.Resource.Destroy(gameObject);
            }
        }
    }
}
