using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Ai_Mutant : MonoBehaviour
{
    public NavMeshAgent agent;
    Animator animator;
    GameObject brain;
    GameObject Enemy;
    [SerializeField]
    private float range=2f;
   
    Vector3 direction;
    WeaponIk weaponIk;
   
    public float cooldown = 1f; //seconds
    private float lastAttackedAt = -9999f;
    public float startHealth = 100;
    private float health;
    public Image healthBar;
    private bool isDead = false;
    BrainController bC;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        brain = GameObject.FindGameObjectWithTag("Brain");
        bC = brain.GetComponent<BrainController>();

        health = startHealth;
     
      
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Destroy(Enemy, 3f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        direction = brain.transform.position - agent.transform.position;
        agent.destination = brain.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (Vector3.Distance(agent.transform.position, brain.transform.position)<=10)
        {
            Attack();
           
           


        }




    }

    public void Attack()
    {

        animator.SetLayerWeight(animator.GetLayerIndex("AttackLayer"), 1);
        animator.SetTrigger("Attack");
        bC.applyDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bulletTower"))
            Destroy(gameObject);

    }
}
