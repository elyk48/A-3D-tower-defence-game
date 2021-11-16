
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    private void Awake()
    { //getting all the waypoints on the map in array of transform 
        waypoints = new Transform[transform.childCount];
        //getting all waypoints
        for (int i = 0; i < waypoints.Length; i++)
        {
           waypoints[i]= transform.GetChild(i);
        }
    }
}
