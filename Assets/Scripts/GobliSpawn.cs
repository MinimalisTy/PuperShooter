using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GobliSpawn : MonoBehaviour
{

    public Transform spawn;
    public List<Transform> patrol;
    public GameObject goblin, GoblinStart;
    public PlayerController player;
    public float spawnTime;
    public float time;
    public float maxHP;
    public float maxSpeed;


    private void Start()
    {
        patrol = GoblinStart.GetComponent<AINavMesh>().patrolPoints;
    }

    private void Update()
    {
        if(spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            spawnTime = time;
            Spawn();
        }
    }

    public void Spawn()
    {
        var gobl = Instantiate(goblin);
        gobl.transform.position = spawn.position;
        gobl.GetComponent<AINavMesh>().patrolPoints = patrol;
        gobl.GetComponent<AINavMesh>().player = player;
        gobl.GetComponent<EnemyHP>().hp = maxHP;
        gobl.GetComponent<EnemyHP>().speed = maxSpeed;
        gobl.GetComponent<NavMeshAgent>().speed = maxSpeed;
    }

}
