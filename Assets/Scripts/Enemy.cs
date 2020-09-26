using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        // Direction pointing to waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        // Checks if we are verrrrry close to a waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        // Enemy has reached the end
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return; // makes sure the code doesn't skip into next node segment (yes this happens)
        }

        // Not at the end, find next waypoint
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
