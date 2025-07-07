using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public Transform enemyPath;
    public float enemyMoveSpeed = 2f;

    Transform[] waypoints;
    int currentWaypointIndex = 0;

    Rigidbody2D m_rigidbody;
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        waypoints = new Transform[enemyPath.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = enemyPath.GetChild(i);
        }
    }
    void FixedUpdate()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];
        Vector2 direction = ((Vector2)target.position - m_rigidbody.position).normalized;
        m_rigidbody.linearVelocity = direction * enemyMoveSpeed;

        if (Vector3.Distance(m_rigidbody.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
                Destroy(gameObject);
        }
    }
}
