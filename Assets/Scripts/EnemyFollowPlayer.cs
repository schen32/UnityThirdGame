using UnityEngine;
public class EnemyFollowPlayer : MonoBehaviour
{
    public float m_enemyMoveSpeed = 2f;

    Transform m_playerTransform;
    Rigidbody2D m_rigidbody;
    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    void FixedUpdate()
    {
        Vector2 direction = ((Vector2)m_playerTransform.position - m_rigidbody.position).normalized;
        m_rigidbody.linearVelocity = direction * m_enemyMoveSpeed;
    }
}
