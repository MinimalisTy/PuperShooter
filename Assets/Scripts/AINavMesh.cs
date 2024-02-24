using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AINavMesh : MonoBehaviour
{
    public List<Transform> patrolPoints;
    //public Transform targetPoint;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool isPlayer;
    public float viewVector;

    private void Start()
    {
        GetLinks();
        RandomTarget();
    }

    void Update()
    {
        RaycastForPlayerUpdate();
        MoveUpdate();
    }











    private void MoveUpdate()
    {
        if (isPlayer)
            _navMeshAgent.destination = player.transform.position;
        else
            GetNewPatrolPoint();
    }


    private void RaycastForPlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        isPlayer = false;
        if (Vector3.Angle(transform.forward, direction) < viewVector)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    isPlayer = true;
                }
            }
        }

    }
    void RandomTarget()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void GetNewPatrolPoint()
    {
        if (_navMeshAgent.remainingDistance == 0)
            RandomTarget();
    }
    private void GetLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

}