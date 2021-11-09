using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI_nav : MonoBehaviour
{
   public NavMeshAgent agent;
    Animator animator;
     GameObject brain;
    [SerializeField]
    private float range;
    private bool Gotwepon = false;
    Vector3 direction;
    WeaponIk weaponIk;
    public GameObject raycastOrigin;
    public float cooldown = 1f; //seconds
    private float lastAttackedAt = -9999f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        brain = GameObject.FindGameObjectWithTag("Brain");
        weaponIk = GetComponent<WeaponIk>();
        
        raycastOrigin = GameObject.FindGameObjectWithTag("Raycast");
        weaponIk.SetaimTransform(raycastOrigin.transform);
    }

    // Update is called once per frame
    void Update()
    {
        direction = brain.transform.position - agent.transform.position;
        agent.destination = brain.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);

        if (Vector3.Distance(agent.transform.position,brain.transform.position)<=range)
        {
            Getwepon();
            Gotwepon = true;
            WeaponIk.SetTargetTransform(brain.transform);

           
        }


        if (Gotwepon)
        {

           // if (Time.time > lastAttackedAt + cooldown)
            //{
                //do the attack
                WeaponIk.SetTargetTransform(brain.transform);
                weaponIk.startfiring();
                animator.SetLayerWeight(animator.GetLayerIndex("AttackLayer"), 1);
                animator.SetBool("shoot", true);
                lastAttackedAt = Time.time;
            //}
           
            
            
           
        }


    }

    public void Getwepon()
    {
        animator.SetLayerWeight(animator.GetLayerIndex("EquipeLayer"), 1);
        animator.SetBool("Equipe", true);
    }

    private void OnTriggerEnter(Collider other)
    {  if(other.CompareTag("bulletTower"))
        Destroy(gameObject);

    }
}
