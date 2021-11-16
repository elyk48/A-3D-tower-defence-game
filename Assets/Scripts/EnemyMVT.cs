
using UnityEngine;

public class EnemyMVT : MonoBehaviour
{  
    public float speed=10f;
    private Transform target;
    private int waypointIndex = 0;
    GameObject brain;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position-transform.position;
        transform.Translate(direction.normalized *speed *Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {

            GetNextwayPoint();
        }
    }
    void GetNextwayPoint()
    {

        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        { brain =GameObject.FindGameObjectWithTag("Brain");
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
