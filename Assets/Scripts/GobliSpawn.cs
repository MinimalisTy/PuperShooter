using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobliSpawn : MonoBehaviour
{

    public Transform spawn;
    public List<Transform> patrol;
    public GameObject goblin, GoblinStart;
    public PlayerController player;
    public float spawnTime;
    float time;
    private void Start()
    {
        time = spawnTime;
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
    }

}
