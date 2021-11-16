
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
        //setting the first targeted way point
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

    //function to call the next way point once the the enemy arrives to the targted waypoint
    void GetNextwayPoint()
    {
        //testing if the waypointIndex is higher or equal than the length of the array
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        { //getting the brain gameobject
            brain =GameObject.FindGameObjectWithTag("Brain");
            //destroying the enemy once arrved to the last waypoint 
            Destroy(gameObject);
            return;
        }
        //incrementing the index of waypoints
        waypointIndex++;
        //calling the next targeted waypoint
        target = Waypoints.waypoints[waypointIndex];
    }
}
