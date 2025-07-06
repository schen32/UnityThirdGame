using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public Transform enemyPath;
    public float enemyMoveSpeed = 2f;

    Transform[] waypoints;
    int currentWaypointIndex = 0;
    void Start()
    {
        waypoints = new Transform[enemyPath.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = enemyPath.GetChild(i);
        }
    }
    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * enemyMoveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
                Destroy(gameObject);
        }
    }
}
