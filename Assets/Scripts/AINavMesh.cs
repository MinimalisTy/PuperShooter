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
    private PlayerHealth playerhp;
    private bool isPlayer;
    public float viewVector;
    public float damage;
    Animator animator;

    private void Start()
    {
        GetLinks();
        RandomTarget();
        playerhp = player.gameObject.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastForPlayerUpdate();
        MoveUpdate();
        if(isPlayer && _navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
        {
            animator.SetBool("TargetPlayer", true);
            Invoke("AttackPose",1);
        }

        else
        {
            CancelInvoke("AttackUpdate");
            animator.SetBool("Attack", false);
            animator.SetBool("TargetPlayer", false);
        }

    }







    private void AttackPose()
    {
        animator.SetBool("Attack", false);
        Invoke("AttackUpdate", 1);
    }
    
    private void AttackUpdate()
    {
        animator.SetBool("TargetPlayer", false);
        playerhp.DealDamage(damage);
        animator.SetBool("Attack", true);
        CancelInvoke();
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
                if (hit.collider.gameObject == player.gameObject && playerhp.hp > 0)
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
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            RandomTarget();
    }
    private void GetLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

}
