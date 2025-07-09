using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{
    public Transform m_enemyPath;
    public float m_enemyMoveSpeed = 2f;

    Transform[] m_waypoints;
    int m_currentWaypointIndex = 0;

    Rigidbody2D m_rigidbody;
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        m_waypoints = new Transform[m_enemyPath.childCount];
        for (int i = 0; i < m_waypoints.Length; i++)
        {
            m_waypoints[i] = m_enemyPath.GetChild(i);
        }
    }
    void FixedUpdate()
    {
        if (m_waypoints.Length == 0) return;

        Transform target = m_waypoints[m_currentWaypointIndex];
        Vector2 direction = ((Vector2)target.position - m_rigidbody.position).normalized;
        m_rigidbody.linearVelocity = direction * m_enemyMoveSpeed;

        if (Vector3.Distance(m_rigidbody.position, target.position) < 0.1f)
        {
            m_currentWaypointIndex++;

            if (m_currentWaypointIndex >= m_waypoints.Length)
                Destroy(gameObject);
        }
    }
}
