using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour

{
    public Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Fixed Fields")]


    public string enemyTag = "Enemy";

    public Transform PartToRotate; //l head mta tower
    public float TurnSpeed = 10f; //vitesse de rotation taa l head ta tower

    public GameObject bulletPrefab; 
    public Transform firePoint; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //updati l fonctions mtaa target seek
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // liste des enemies
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
 
        foreach (GameObject enemy in enemies)
        {
            //distance entre l tourelle wel enemey 
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); 
            if (distanceToEnemy < shortestDistance)
            { //assigini les valeurs mtaa nearest enemey wel shortest distance
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        } 
        //assigini l target ll nearest enemy li lkineh ki yabda fel range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //Target Lock ON 
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
            PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (Vector3.Distance(transform.position,target.position)<=range)
            {
                Shoot();
                // formule l bullets
                fireCountDown = 1f / fireRate;
            }
            fireRate -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    //Range Of hit display
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
