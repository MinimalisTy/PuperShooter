using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHP : MonoBehaviour
{
    public float hp = 100;
    Animator animator;
    private PlayerProgress Player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Player = FindObjectOfType<PlayerProgress>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            {
                DealDamage(collision.gameObject.GetComponent<Fireball>().damage);
            }
        }
    }



    public void DealDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            animator.SetBool("Death", true);
            Death05();
            Invoke("Death", 4);
        }
        else
        {
            animator.SetBool("Hit", true);
        }
        gameObject.GetComponent<NavMeshAgent>().speed = 0;
        Invoke("HitStop", 0.3f);
        Player.AddExperiance(damage);
        
    }


    public void HitStop()
    {
        animator.SetBool("Hit", false);
        gameObject.GetComponent<AINavMesh>().CancelInvoke("AttackUpdate");
        gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
    }

    public void Death05()
    {
        GetComponent<AINavMesh>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<AINavMesh>().CancelInvoke("AttackUpdate");
    }

    public void Death()
    {
        Destroy(gameObject);
    }


}
