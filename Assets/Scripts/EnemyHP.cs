using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    public float hp = 100;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            {
                hp -= collision.gameObject.GetComponent<Fireball>().damage;
                animator.SetBool("Hit", true);
                gameObject.GetComponent<NavMeshAgent>().speed = 0;
                Invoke("HitStop", 0.3f);
            }
        }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            animator.SetBool("Death", true);
            Death05();
            Invoke("Death", 4);
        }
    }


    public void DealDamage(float damage)
    {
        hp -= damage;
    }


    public void HitStop()
    {
        animator.SetBool("Hit", false);
        gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
    }

    public void Death05()
    {
        GetComponent<AINavMesh>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    public void Death()
    {
        Destroy(gameObject);
    }


}
